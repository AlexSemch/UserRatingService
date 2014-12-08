using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRatingService.Repository;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var reposytory = FakeRepository.GetRepository();
            reposytory.AddUserAsync(new User(1, "sdfs"));
            reposytory.AddUserAsync(new User(1, "sdf"));
        }
    }
}
