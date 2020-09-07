namespace MaskApi.models
{
    public class Mask
    {   
        public string MaskId { get; set; }
        public int Size { get; set; }
        public string Colour { get; set; }
        public bool New { get; set; }
        public bool PreInfected { get; set; }
        public string Design { get; set; }
        public bool Reusable { get; set; }
        public double Cost { get; set; }

        public Mask(string maskId, int size, string colour, bool @new, bool preInfected, string design, bool reusable, double cost)
        {
            MaskId = maskId;
            Size = size;
            Colour = colour;
            New = @new;
            PreInfected = preInfected;
            Design = design;
            Reusable = reusable;
            Cost = cost;
        }

    }
}