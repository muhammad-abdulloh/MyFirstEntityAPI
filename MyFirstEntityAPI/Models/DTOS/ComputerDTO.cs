namespace MyFirstEntityAPI.Models.DTOS
{
    public class ComputerDTO
    {
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public int RAM { get; set; }
        public int GPU { get; set; }
        public int HardDiskHDD { get; set; }
        public int HardDiskSSD { get; set; }
        public string CPU { get; set; }
    }
}
