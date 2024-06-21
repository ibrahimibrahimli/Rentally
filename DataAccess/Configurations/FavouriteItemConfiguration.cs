﻿using Core.DefaultValues;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class FavouriteItemConfiguration : IEntityTypeConfiguration<FavouriteItem>
    {
        public void Configure(EntityTypeBuilder<FavouriteItem> builder)
        {
            builder.ToTable("FavouriteItems");

            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_SEED_VALUE, increment: 1);

            builder.HasOne(x => x.Car)
                .WithMany(x => x.FavouriteItems)
                .HasForeignKey(x => x.CarId);

            



        }
    }
}
