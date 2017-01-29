namespace IoTModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Aggregator> Aggregators { get; set; }
        public virtual DbSet<Aggregator_Data> Aggregator_Data { get; set; }
        public virtual DbSet<Cluster> Clusters { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Sensor> Sensors { get; set; }
        public virtual DbSet<Sensor_Data> Sensor_Data { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Thing> Things { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aggregator>()
                .HasMany(e => e.Aggregator_Data)
                .WithRequired(e => e.Aggregator)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Aggregator>()
                .HasMany(e => e.Sensors)
                .WithRequired(e => e.Aggregator)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cluster>()
                .HasMany(e => e.Aggregators)
                .WithRequired(e => e.Cluster)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.location_name)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.Clusters)
                .WithRequired(e => e.Location)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sensor>()
                .HasMany(e => e.Sensor_Data)
                .WithRequired(e => e.Sensor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Thing>()
                .Property(e => e.thing_name)
                .IsUnicode(false);

            modelBuilder.Entity<Thing>()
                .HasMany(e => e.Sensor_Data)
                .WithRequired(e => e.Thing)
                .WillCascadeOnDelete(false);
        }
    }
}
