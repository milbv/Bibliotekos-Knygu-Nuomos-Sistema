using LibraryAPI.Core.Contracts;
using LibraryAPI.Core.Repositories;
using LibraryAPI.Core.Services;
using Serilog;
using Serilog.Configuration;

namespace LibraryAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            IUserRepository userRepository = new UserRepository("Server=MIL;Database=LibraryAPI;Trusted_Connection=True;TrustServerCertificate=true;");
            IBookRepository bookRepository = new BookRepository("Server=MIL;Database=LibraryAPI;Trusted_Connection=True;TrustServerCertificate=true;");
            IRentRepository rentRepository = new RentRepository("Server=MIL;Database=LibraryAPI;Trusted_Connection=True;TrustServerCertificate=true;");
            IBookService bookService = new BookService(bookRepository);
            IRentService rentService = new RentService(rentRepository, bookRepository);

            builder.Services.AddTransient<IUserRepository, UserRepository>(x => new UserRepository("Server=MIL;Database=LibraryAPI;Trusted_Connection=True;TrustServerCertificate=true;"));
            builder.Services.AddTransient<IBookRepository, BookRepository>(x => new BookRepository("Server=MIL;Database=LibraryAPI;Trusted_Connection=True;TrustServerCertificate=true;"));
            builder.Services.AddTransient<IRentRepository, RentRepository>(x => new RentRepository("Server=MIL;Database=LibraryAPI;Trusted_Connection=True;TrustServerCertificate=true;"));
            builder.Services.AddTransient<IRentService, RentService>();
            builder.Services.AddTransient<IBookService, BookService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();

            var log = new LoggerConfiguration().MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/library.txt", rollingInterval: RollingInterval.Day).CreateLogger();
            Log.Logger = log;
        }
    }
}
