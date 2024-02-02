﻿using DSharpPlus;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.CommandsNext.Exceptions;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;
using KWiJisho.Modules.Commands.Prefix;
using KWiJisho.Modules.Commands.Slash;
using KWiJisho.Modules.Events;
using KWiJisho.Modules.Utils;
using System.Collections.Generic;

namespace KWiJisho.Modules
{
    /// <summary>
    /// The main entry point of the application.
    /// </summary>
    internal partial class Bot
    {
        /// <summary>
        /// Register all the Discord bot prefix commands.
        /// </summary>
        internal void RegisterPrefixCommands()
        {
            // Registering discord bot prefix commands.
            PrefixCommands.RegisterCommands<PrefixCommandManager.PrefixBasic>();
            PrefixCommands.RegisterCommands<PrefixCommandManager.PrefixBirthday>();
            PrefixCommands.RegisterCommands<PrefixCommandManager.PrefixInfo>();
            PrefixCommands.RegisterCommands<PrefixCommandManager.PrefixKwiGpt>();
            PrefixCommands.RegisterCommands<PrefixCommandManager.PrefixNasa>();
            PrefixCommands.RegisterCommands<PrefixCommandManager.PrefixTheme.PrefixThemeTramontina>();
        }

        /// <summary>
        /// Register all the Discord bot slash commands.
        /// </summary>
        internal void RegisterSlashCommands()
        {
            // Discord Server ID. If set to null, slash commmands will register to all servers that the bot is in (changes
            // take up to an hour to apply)
            List<ulong> guildIds =
            [
                737541664318554143, // Personal Discord server.
                692588978959941653 // Tramontina Discord server.
            ];

            foreach (var guildId in guildIds)
            {
                // Registering discord bot slash commands.
                SlashCommands.RegisterCommands<SlashBasic>(guildId);
                SlashCommands.RegisterCommands<SlashBirthday>(guildId);
                SlashCommands.RegisterCommands<SlashInfo>(guildId);
                SlashCommands.RegisterCommands<SlashKwiGpt>(guildId);
            }
        }

        /// <summary>
        /// Register all the Discord bot events.
        /// </summary>
        /// <returns></returns>
        internal void RegisterBotEvents()
        {
            // Registering discord bot events.
            DiscordClient.Ready += BotStart.OnClientReady;
            DiscordClient.ComponentInteractionCreated += Buttons.OnComponentInteractionCreatedAsync;
            DiscordClient.GuildMemberAdded += GoodbyeWelcome.OnGuildMemberAddedAsync;
            DiscordClient.GuildMemberRemoved += GoodbyeWelcome.OnGuildMemberRemovedAsync;
        }

        internal void RegisterPrefixCommandsPermissions()
        {
            PrefixCommands.CommandErrored += async (sender, exception) =>
            {
                // Checking if the exception is a checks failed exception.
                if (exception.Exception is ChecksFailedException checkFailedException)
                {
                    // Iterate over the failed checks.
                    foreach (var check in checkFailedException.FailedChecks)
                    {
                        // Check if the failed check is a require user permissions attribute.
                        if (check is RequireUserPermissionsAttribute requireUserPermissionAttribute)
                        {
                            // Send a custom error message to the user.
                            await exception.Context.RespondAsync(KWiJishoPermission.PermissionCustomErrorMessage(requireUserPermissionAttribute.Permissions));
                        }
                    }
                }
            };
        }
        internal void RegisterSlashCommandsPermissions()
        {
            SlashCommandsExtension slash = SlashCommands;
            slash.SlashCommandErrored += async (s, e) =>
            {
                // Checking if the exception is a slash execution checks failed exception.
                if (e.Exception is SlashExecutionChecksFailedException slashExecutionChecksFailedException)
                {
                    // Iterate over the failed checks
                    foreach (var check in slashExecutionChecksFailedException.FailedChecks)
                    {
                        // Check if the failed check is a slash require user permissions attribute.
                        if (check is SlashRequireUserPermissionsAttribute slashRequireUserPermissionsAttribute)
                        {
                            // Send a custom error message to the user.
                            await e.Context.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,
                                new DiscordInteractionResponseBuilder().WithContent(KWiJishoPermission.PermissionCustomErrorMessage(slashRequireUserPermissionsAttribute.Permissions)));
                        }
                    }
                }
            };
        }
    }
}
