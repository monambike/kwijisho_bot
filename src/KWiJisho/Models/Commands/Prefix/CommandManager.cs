﻿using ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KWiJisho.Models.Commands.Prefix
{
    /// <summary>
    /// Represent the class that represents commands groups and holds all Discord command classes.
    /// </summary>
    internal static partial class PrefixCommandManager
    {
        internal static List<PrefixCommandGroup> CommandGroups { get; set; } = [];

        internal static PrefixCommandGroup Astronomy => new("Nasa e Astronomia");
        internal static PrefixCommandGroup ChatGpt => new("ChatGpt (Estilo KWiJisho 🌟)");
        internal static PrefixCommandGroup Info => new("Informações Adicionais");
        internal static PrefixCommandGroup Theme => new("Mudar Tema do Servidor");
        internal static PrefixCommandGroup Birthday => new("Aniversário");
        internal static PrefixCommandGroup Basic => new("Comandos Básicos");
    }

    /// <summary>
    /// Represents a single Discord command.
    /// </summary>
    internal class PrefixCommand
    {
        internal string Name { get; set; }

        internal string Description { get; set; }

        internal bool OwnerCommand { get; set; } = false;

        internal PrefixCommand(string name, string description, PrefixCommandGroup group)
        {
            Name = name;
            Description = description;

            var selectedCommandGroup = PrefixCommandManager.CommandGroups.Where(commandGroup => commandGroup.Name == group.Name).FirstOrDefault();
            selectedCommandGroup.Commands.Add(this);
        }

        internal PrefixCommand(string name, string description, PrefixCommandGroup group, bool ownerCommand)
            : this(name, $"{description}{Environment.NewLine}" + "Esse comando só pode ser executado pelo dono do bot".ToDiscordItalic(), group)
        {
            OwnerCommand = ownerCommand;
        }
    }

    /// <summary>
    /// Represents a group and holds a list with a set of Discord commands.
    /// </summary>
    internal partial class PrefixCommandGroup
    {
        internal string Name { get; set; }

        internal List<PrefixCommand> Commands { get; set; } = [];

        internal PrefixCommandGroup(string name)
        {
            Name = name;
            if (!PrefixCommandManager.CommandGroups.Any(commandGroup => commandGroup.Name == name))
                PrefixCommandManager.CommandGroups.Add(this);
        }

        public override string ToString() => Name;
    }
}
