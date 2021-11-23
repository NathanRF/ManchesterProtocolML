namespace ManchesterProtocolML.Models
{
    public class PrioridadeResponse
    {
        public string result { get; set; }
        public int PriorityCode
        {
            get => result switch
            {
                "Emergent" => 4,
                "VeryUrgent" => 3,
                "Urgent" => 2,
                "Standard" => 1,
                "NonUrgent" => 0
            };
        }
    }
}
