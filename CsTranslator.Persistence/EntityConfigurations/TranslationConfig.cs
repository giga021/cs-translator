using CsTranslator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CsTranslator.Persistence.EntityConfigurations
{
	class TranslationConfig : IEntityTypeConfiguration<Translation>
	{
		public void Configure(EntityTypeBuilder<Translation> builder)
		{
			builder.ToTable("Translations");
			builder.HasOne(x => x.User).WithMany().IsRequired().HasForeignKey(x => x.UserId);
		}
	}
}
