using Abp.Application.Services.Dto;
using AppBoilerplate.Authorization.Users;
using AppBoilerplate.Users;
using AppBoilerplate.Users.Dto;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace AppBoilerplate.Tests.Users
{
    public class UserAppService_Tests : AppBoilerplateTestBase
    {
        private readonly IUserAppService _userAppService;

        public UserAppService_Tests()
        {
            _userAppService = Resolve<IUserAppService>();
        }

        [Fact]
        public async Task GetUsers_Test()
        {
            // Act
            var output = await _userAppService.GetAllAsync(new PagedUserResultRequestDto{MaxResultCount=20, SkipCount=0} );

            // Assert
            output.Items.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task CreateUser_Test()
        {
            // Act
            await _userAppService.CreateAsync(
                new CreateUserDto
                {
                    EmailAddress = "john@volosoft.com",
                    IsActive = true,
                    Name = "John",
                    Surname = "Nash",
                    Password = "123qwe",
                    UserName = "john.nash"
                });

            await UsingDbContextAsync(async context =>
            {
                var johnNashUser = await context.Users.FirstOrDefaultAsync(u => u.UserName == "john.nash");
                johnNashUser.ShouldNotBeNull();
            });
        }

        [Fact]
        public async Task UpdateUser_Teste()
        {
            var user = await _userAppService.CreateAsync(
                new CreateUserDto
                {
                    EmailAddress = "marcos@appboilerplate.com",
                    IsActive = true,
                    Name = "Marcos",
                    Surname = "Levy",
                    Password = "123qwe",
                    UserName = "marcos.levy"
                });

            await _userAppService.UpdateAsync(
                new UserDto
                {
                    Id = user.Id,
                    EmailAddress = "marcos@appboilerplate.com",
                    IsActive = true,
                    Name = "Anna",
                    Surname = "Caroline",
                    UserName = "anna.caroline"
                });

            await UsingDbContextAsync(async context =>
            {
                var user = await context.Users.FirstOrDefaultAsync(u => u.UserName == "anna.caroline");
                user.ShouldNotBeNull();
            });
        }

        [Fact]
        public async Task DeleteUser_Teste()
        {
            var user = await _userAppService.CreateAsync(
                new CreateUserDto
                {
                    EmailAddress = "annaelisa@appboilerplate.com",
                    IsActive = true,
                    Name = "Anna",
                    Surname = "Elisa",
                    Password = "123qwe",
                    UserName = "anna.elisa"
                });

            await _userAppService.DeleteAsync(new EntityDto<long>(user.Id));

            await UsingDbContextAsync(async context =>
            {
                var user = await context.Users.FirstOrDefaultAsync(u => u.UserName == "anna.elisa");
                user.Equals(null);
            });
        }

        //[Fact]
        //public async Task CreateUserWithoutEmail_Teste()
        //{
        //    // Act
        //    await _userAppService.CreateAsync(
        //        new CreateUserDto
        //        {
        //            IsActive = true,
        //            Name = "Anna",
        //            Surname = "Elisa",
        //            Password = "123qwe",
        //            UserName = "anna.elisa"
        //        });

        //    await UsingDbContextAsync(async context =>
        //    {
        //        var user = await context.Users.FirstOrDefaultAsync(u => u.UserName == "anna.elisa");
        //        user.ShouldNotBeNull();
        //    });
        //}

        [Fact]
        public async Task DeActivateUser()
        {
            var users = await _userAppService.GetAllAsync(new PagedUserResultRequestDto { MaxResultCount = 20, SkipCount = 0 });

            await _userAppService.DeActivate(users.Items[0]);

            await UsingDbContextAsync(async context =>
            {
                var user = await context.Users.FirstOrDefaultAsync(u => u.UserName == "admin");
                user.ShouldNotBeNull();
            });
        }


    }
}
