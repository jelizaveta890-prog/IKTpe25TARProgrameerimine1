using University.Dto;
using University.Models;

namespace University.ServicInterface
{
    public interface IFileServices
    {
        void FilesToApi(CourseDto dto, Course domain);
        Task<FileToApi?> RemoveImageFolder(FileToApiDto dto);

    }
}
