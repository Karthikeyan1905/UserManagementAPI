
using System.Configuration;
using UserManagement.Bussiness.Repository;
using UserManagement.Bussiness.RepositoryInterface;

namespace UserManagementAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
           

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            try
            {
                builder.Services.AddSwaggerGen();
            
            builder.Services.AddScoped<IUserInfoRepository>(provider =>
    new UserInfoRepository(builder.Configuration.GetConnectionString("connstr")));
                builder.Services.AddScoped<IAddressRepository>(provider =>
        new AddressRepository(builder.Configuration.GetConnectionString("connstr")));
                       builder.Services.AddScoped<IDepartmentRepository>(provider =>
                new DepartmentRepository(builder.Configuration.GetConnectionString("connstr")));
                        builder.Services.AddScoped<IDesignationRepository>(provider =>
                new DesignationRepository(builder.Configuration.GetConnectionString("connstr")));
                        builder.Services.AddScoped<IEducationRepository>(provider =>
                new EducationRepository(builder.Configuration.GetConnectionString("connstr")));
                       builder.Services.AddScoped<IEmployeeRepository>(provider =>
                new EmployeeRepository(builder.Configuration.GetConnectionString("connstr")));
                       builder.Services.AddScoped<IExperienceRepository>(provider =>
               new ExperienceRepository(builder.Configuration.GetConnectionString("connstr")));
                     builder.Services.AddScoped<ILoginCredentialRepository>(provider =>
                new LoginCredentialRepository(builder.Configuration.GetConnectionString("connstr")));
                       builder.Services.AddScoped<ILoginHistoryRepository>(provider =>
                new LoginHistoryRepository(builder.Configuration.GetConnectionString("connstr")));
                        builder.Services.AddScoped<IPhoneRepository>(provider =>
                new PhoneRepository(builder.Configuration.GetConnectionString("connstr")));
                        builder.Services.AddScoped<ITeamRepository>(provider =>
                new TeamRepository(builder.Configuration.GetConnectionString("connstr")));
                        builder.Services.AddScoped<ITeamUserRepository>(provider =>
                new TeamUserRepository(builder.Configuration.GetConnectionString("connstr")));
            }
            catch (Exception ex)
            {
                string exMessage = ex.Message;

            }

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {   
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
