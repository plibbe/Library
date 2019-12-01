﻿using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Persistence.Configurations.EFCoreConfigurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(f => f.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(l => l.LastName)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}