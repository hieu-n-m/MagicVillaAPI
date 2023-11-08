using MagicVilla_VillaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaAPI.Data
{
	public class VillaContext : DbContext
	{
		public VillaContext(DbContextOptions<VillaContext> options) : base(options)
		{
		}
		public DbSet<LocalUser> LocalUsers { get; set; }
		public DbSet<Villa> Villas { get; set; } // the table name in db
		public DbSet<VillaNumber> VillaNumbers { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Payment> Payments { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Villa>().HasData(
				new Villa
				{
					Id = 1,
					Amenity = "",
					CreatedDate = DateTime.Now,
					Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
					ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa3.jpg",
					Name = "Royal Villa",
					Occupancy = 4,
					Rate = 200.0,
					SquareFeet = 550,
					UpdatedDate = DateTime.Now
				},
				new Villa
				{
					Id = 2,
					Amenity = "",
					CreatedDate = DateTime.Now,
					Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
					ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa1.jpg",
					Name = "Premium Pool Villa",
					Occupancy = 4,
					Rate = 300.0,
					SquareFeet = 550,
					UpdatedDate = DateTime.Now
				},
				new Villa
				{
					Id = 3,
					Amenity = "",
					CreatedDate = DateTime.Now,
					Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
					ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa4.jpg",
					Name = "Luxury Pool Villa",
					Occupancy = 4,
					Rate = 400.0,
					SquareFeet = 750,
					UpdatedDate = DateTime.Now
				},
				new Villa
				{
					Id = 4,
					Amenity = "",
					CreatedDate = DateTime.Now,
					Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
					ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa5.jpg",
					Name = "Diamond Villa",
					Occupancy = 4,
					Rate = 550.0,
					SquareFeet = 900,
					UpdatedDate = DateTime.Now
				},
				new Villa
				{
					Id = 5,
					Amenity = "",
					CreatedDate = DateTime.Now,
					Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
					ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa2.jpg",
					Name = "Diamond Pool Villa",
					Occupancy = 4,
					Rate = 600.0,
					SquareFeet = 1100,
					UpdatedDate = DateTime.Now
				});
			//modelBuilder.Entity<VillaNumber>().HasData(
			//	new VillaNumber
			//	{
			//		VillaNo = 1,
			//		CreatedDate = DateTime.Now,
			//		Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
			//		UpdatedDate = DateTime.Now
			//	},
			//	new VillaNumber
			//	{
			//		VillaNo = 2,
			//		CreatedDate = DateTime.Now,
			//		Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
			//		UpdatedDate = DateTime.Now
			//	});
		}
	}
}
