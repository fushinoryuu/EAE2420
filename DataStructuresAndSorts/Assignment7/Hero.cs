namespace Assignment7
{
    class Hero
    {
        public string Name { get; set; }
        public int Attack { get; set; }

        public override int GetHashCode()
        {
            return (Name.GetHashCode() ^ Attack.GetHashCode());
        }

        public override bool Equals(object obj)
        {
            Hero other = (Hero)obj;
            return Name == other.Name && Attack == other.Attack;
        }
    }
}