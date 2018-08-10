namespace Alore.Room.Models.Entities
{
    using Alore.API.Network.Packets;
    using Alore.API.Room.Entities;
    using Alore.API.Room.Grid;
    using Alore.API.Room.Models;
    using Alore.Room.Packets.Outgoing;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class EntityHandler : IDisposable
    {
        private readonly IRoom _room;

        internal IDictionary<int, BaseEntity> Entities { get; private set; }
        internal bool HasUserEntities => Entities.Where(x => x.Value is UserEntity).Any();

        private readonly StringBuilder _moveStatus;

        internal EntityHandler(IRoom room)
        {
            _room = room;

            Entities = new Dictionary<int, BaseEntity>();

            _moveStatus = new StringBuilder();
        }

        internal async void Cycle(DateTimeOffset timeOffset)
        {
            foreach (BaseEntity entity in Entities.Values)
            {
                if (entity.NextPosition != entity.Position)
                {
                    entity.Position = entity.NextPosition;
                }

                if (entity.PathToWalk != null)
                {
                    //Finished walking or found no path.
                    if (entity.PathToWalk.Count == 0)
                    {
                        entity.ActiveStatuses.Remove("mv");
                        entity.PathToWalk = null;
                        return;
                    }

                    entity.ActiveStatuses.Remove("mv");

                    int reversedIndex = entity.PathToWalk.Count - 1;
                    Position nextStep = entity.PathToWalk[reversedIndex];
                    entity.PathToWalk.RemoveAt(reversedIndex);

                    int newDir = Position.CalculateDirection(entity.Position, nextStep);

                    entity.NextPosition.X = nextStep.X;
                    entity.NextPosition.Y = nextStep.Y;
                    entity.BodyRotation = newDir;

                    _moveStatus
                        .Clear()
                        .Append(nextStep.X)
                        .Append(",")
                        .Append(nextStep.Y)
                        .Append(",")
                        .Append("0.00");
                    entity.ActiveStatuses.Add("mv", _moveStatus.ToString());
                }
                else
                {
                    if (entity.ActiveStatuses.ContainsKey("mv"))
                    {
                        entity.ActiveStatuses.Remove("mv");
                    }
                }
            }

            await SendAsync(new EntityUpdateComposer(Entities.Values));
        }

        internal async Task SendAsync(ServerPacket packet)
        {
            foreach (BaseEntity entity in Entities.Values)
            {
                if (entity is UserEntity userEntity)
                {
                    await userEntity.Session.WriteAndFlushAsync(packet);
                }
            }
        }

        internal void RemoveEntity(int entityId)
        {
            if (Entities.ContainsKey(entityId))
            {
                Entities.Remove(entityId);
            }
        }

        internal void AddEntity(BaseEntity entity)
        {
            Entities.Add(entity.Id, entity);
        }

        public void Dispose()
        {
            foreach (BaseEntity entity in Entities.Values)
            {
                //entity.Dispose();
            }

            Entities = null;
        }
    }
}
