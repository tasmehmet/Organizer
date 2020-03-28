namespace Organizer.Domain.Models
{
    public class CmsEntityBase : Entity
    {
        public string Lang { get; set; }
        public string Permalink { get; set; }
    }
    public abstract class CmsEntity : CmsEntityBase
    {
        public bool? Deleted { get; set; }
        public override bool Equals(object obj)
        {
            var compareTo = obj as CmsEntity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return ID.Equals(compareTo.ID);
        }

        public static bool operator ==(CmsEntity a, CmsEntity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(CmsEntity a, CmsEntity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + ID.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + ID + "]";
        }
    }
}