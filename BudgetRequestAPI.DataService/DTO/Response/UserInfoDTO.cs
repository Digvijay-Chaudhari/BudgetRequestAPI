namespace BudgetRequestAPI.DataService.DTO.Response
{
    public class UserInfoDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string Designation { get; set; }
        public int? ManagerId { get; set; }
        public bool? IsManager { get; set; }
    }
}
