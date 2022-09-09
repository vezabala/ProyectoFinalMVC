namespace Actividad7.Models
{
    public abstract class Entity
    {
        public int Id { get; protected set; }

        /// <summary>
        /// for
        /// </summary>
        protected Entity()
        {

        }

        protected Entity(int id)
        {
            Id = id;
        }

    }
}
