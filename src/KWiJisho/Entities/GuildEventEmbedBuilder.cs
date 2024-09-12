﻿// Copyright(c) 2024 Vinicius Gabriel Marques de Melo. All rights reserved.
// Contact: @monambike for more information.
// For license information, please see the LICENSE file in the root directory.

using DSharpPlus.Entities;
using static KWiJisho.Events.DiscordGuildHandler;

namespace KWiJisho.Entities
{
    /// <summary>
    /// Represents a Discord Guild Event along with their identifier information.
    /// </summary>
    public class GuildEventEmbedBuilder
    {
        /// <summary>
        /// Title for guild event.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Generated description for guild event.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Image for guild event.
        /// </summary>
        public required string ImageUrl { get; set; }

        /// <summary>
        /// UpdateType for guild event.
        /// </summary>
        public required EventType UpdateType { get; set; }

        /// <summary>
        /// DiscordUser for guild event. Required to generate the description.
        /// </summary>
        public DiscordUser DiscordUser { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="GuildEventEmbedBuilder"/> class.
        /// </summary>
        public GuildEventEmbedBuilder()
        {
            if (DiscordUser is not null)
                UpdateDescription();
        }

        public void UpdateDescription() => UpdateDescription(DiscordUser);

        public void UpdateDescription(DiscordUser discordUser) => (DiscordUser, Description) = (discordUser, GetRandomMessageByType(UpdateType, discordUser.Mention));
    }
}