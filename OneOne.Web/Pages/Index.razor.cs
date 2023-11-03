using Microsoft.AspNetCore.Components;
using OneOne.Shared.Entities;
using OneOne.Shared.Models;
using OneOne.Web.Services;

namespace OneOne.Web.Pages
{
    public partial class Index
    {
        [Inject]
        public IStudentService service { get; set; }

        //public Student newStudent { get; set; } = new Student();

        public IEnumerable<StudentModel> Students { get; set; } = new List<StudentModel>();
        protected override async Task OnInitializedAsync()
        {
            //return base.OnInitializedAsync();
            Students = await service.GetStudentsAsync();
        }
    }
}
