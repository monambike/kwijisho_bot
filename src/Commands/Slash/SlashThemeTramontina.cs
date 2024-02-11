﻿using DSharpPlus;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;
using System.Threading.Tasks;

namespace KWiJisho.Commands.Slash
{
    /// <summary>
    /// Represents a set of notice slash commands.
    /// </summary>
    internal class SlashThemeTramontina : ApplicationCommandModule
    {

        [SlashCommand("theme-reset", "Volta o tema do servidor para o Padrão!!")]
        [SlashRequireUserPermissions(Permissions.Administrator)]
        internal static async Task ExecuteSlashResetAsync(InteractionContext interactionContext)
        {
            // Acknowledge the interaction by deferring the response with a loading state.
            await interactionContext.CreateResponseAsync(InteractionResponseType.DeferredChannelMessageWithSource);

            // Call the SendNewsAsync method from the Notice class to send the news with provided parameters.
            await ThemeTramontina.ResetThemeAsync(interactionContext.Channel, interactionContext.Client);

            // Delete the initial acknowledgment message after processing the command.
            await interactionContext.DeleteResponseAsync();
        }

        [SlashCommand("theme-christmas", "🎅🏻 Define o tema do servidor para o de Natal!!")]
        [SlashRequireUserPermissions(Permissions.Administrator)]
        internal static async Task ExecuteSlashChristmasAsync(InteractionContext interactionContext)
        {
            // Acknowledge the interaction by deferring the response with a loading state.
            await interactionContext.CreateResponseAsync(InteractionResponseType.DeferredChannelMessageWithSource);

            // Call the SendNewsAsync method from the Notice class to send the news with provided parameters.
            await ThemeTramontina.SetChristmasThemeAsync(interactionContext.Channel, interactionContext.Client);

            // Delete the initial acknowledgment message after processing the command.
            await interactionContext.DeleteResponseAsync();
        }

        [SlashCommand("theme-easter", "🐇 Define o tema do servidor para o de Páscoa!!")]
        [SlashRequireUserPermissions(Permissions.Administrator)]
        internal static async Task ExecuteSlashEasterAsync(InteractionContext interactionContext)
        {
            // Acknowledge the interaction by deferring the response with a loading state.
            await interactionContext.CreateResponseAsync(InteractionResponseType.DeferredChannelMessageWithSource);

            // Call the SendNewsAsync method from the Notice class to send the news with provided parameters.
            await ThemeTramontina.SetEasterThemeAsync(interactionContext.Channel, interactionContext.Client);

            // Delete the initial acknowledgment message after processing the command.
            await interactionContext.DeleteResponseAsync();
        }

        [SlashCommand("theme-halloween", "🎃 Define o tema do servidor para o de Halloween!!")]
        [SlashRequireUserPermissions(Permissions.Administrator)]
        internal static async Task ExecuteSlashHalloweenAsync(InteractionContext interactionContext)
        {
            // Acknowledge the interaction by deferring the response with a loading state.
            await interactionContext.CreateResponseAsync(InteractionResponseType.DeferredChannelMessageWithSource);

            // Call the SendNewsAsync method from the Notice class to send the news with provided parameters.
            await ThemeTramontina.SetHalloweenThemeAsync(interactionContext.Channel, interactionContext.Client);

            // Delete the initial acknowledgment message after processing the command.
            await interactionContext.DeleteResponseAsync();
        }
    }
}
