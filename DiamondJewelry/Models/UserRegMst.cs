namespace DiamondJewelry.Models
{
    public class UserRegMst
    {
        public int UserID { get; set; } // Khóa chính
        public string UserFname { get; set; }
        public string UserLname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string MobNo { get; set; }
        public string EmailID { get; set; }
        public DateTime Dob { get; set; }
        public DateTime CDate { get; set; }
        public string Password { get; set; }
    }
}