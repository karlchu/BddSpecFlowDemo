using BddSpecFlowDemo.Controllers;
using BddSpecFlowDemo.Models;

namespace BddSpecFlowDemo.Services
{
    public interface IAlbumsService
    {
        Album SearchByTitle(string searchString);
    }
}