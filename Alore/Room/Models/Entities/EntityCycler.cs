namespace Alore.Room.Models.Entities
{
    using Alore.API.Room.Entities;
    using Alore.API.Room.Grid;
    using Alore.API.Room.Models;
    using System.Text;

    internal class EntityCycler
    {
        private readonly IRoom _room;
        private readonly StringBuilder _moveStatus;

        internal EntityCycler(IRoom room)
        {
            _room = room;
            _moveStatus = new StringBuilder();
        }

        internal void Cycle(BaseEntity entity)
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
    }
}