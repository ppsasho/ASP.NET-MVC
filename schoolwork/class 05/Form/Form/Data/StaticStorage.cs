using Form.Models;

namespace Form.Data
{
    public static class StaticStorage
    {
        public static List<StudentViewModel> Students { get; set; } = new List<StudentViewModel>()
        {
            new StudentViewModel
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                Group = GroupEnum.G3
            }
        };
    }
}
