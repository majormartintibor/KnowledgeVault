﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace meShop.SharedKernel.Persistence.Inbox;
public sealed class InboxMessageConsumerConfiguration : IEntityTypeConfiguration<InboxMessageConsumer>
{
    public void Configure(EntityTypeBuilder<InboxMessageConsumer> builder)
    {
        builder.ToTable("inbox_message_consumers");

        builder.HasKey(o => new { o.InboxMessageId, o.Name });

        builder.Property(o => o.Name).HasMaxLength(500);
    }
}