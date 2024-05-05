namespace NIC
{
    public enum NICType
    {
        Ethernet, TokenRing
    }
    class NIC
    {
        public  string Manufacture { get; init; }
        public  string MacAddress { get; init; }
        public NICType Type { get; init; }

        NIC(string manufacture = "", string macAddress = "", NICType type = NICType.Ethernet)
        {
            Manufacture = manufacture;
            MacAddress = macAddress;
            Type = type;
        }

        static NIC obj = null;

        public static NIC createNIC(string manufacture, string macAddress, NICType type)
        {
            if(obj == null) 
                obj = new NIC(manufacture,macAddress,type);

            return obj;
        }

        public override string ToString()
        {
            return $" {Manufacture} - {MacAddress} - {Type}";
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            NIC nc1 = NIC.createNIC("E", "13 14", NICType.TokenRing);
            NIC nc2 = NIC.createNIC("V", "15 16", NICType.Ethernet);
            Console.WriteLine(nc2);
        }
    }
   
}
