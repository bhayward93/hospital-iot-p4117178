namespace IoTModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Aggregator_Data
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int aggregator_data_id { get; set; }

        public int aggregator_id { get; set; }

        public int sensor_id { get; set; }

        public int? sensor_data_id { get; set; }

        public virtual Aggregator Aggregator { get; set; }

        public virtual Sensor_Data Sensor_Data { get; set; }
    }
}
