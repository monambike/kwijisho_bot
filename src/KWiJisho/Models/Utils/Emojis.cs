﻿using System;
using System.Collections.Generic;

namespace KWiJisho.Models.Utils
{
    internal static class Emojis
    {
        internal static class AnimatedEmojis
        {
            // Every added emoji will come to this list
            internal static List<Emoji> KWiJishoEmojis = [];


            internal static List<CatMemeEmoji> KWiJishoMemeEmojis = [];
            // Cat memes
            internal static CatMemeEmoji MemeChipiCat = new("cat_chipichipi", 1200609170567745566);
            internal static CatMemeEmoji MemeAppleCat = new("cat_happycat_apple", 1200610022556704788);
            internal static CatMemeEmoji MemeBananaCat = new("cat_happycat_banana", 1200609322573512795);
            internal static CatMemeEmoji MemeHappyCat = new("cat_happycat_happy", 1200608921660960768);


            internal static List<CatPartyEmoji> KWiJishoPartyEmojis = [];
            // Cat party emojis
            internal static CatPartyEmoji CatCoke = new("cat_coke", 1200610043901509672);
            // Cat party dance emojis
            internal static CatPartyEmoji CatParty1 = new("cat_party_1", 1200610219240198224);
            internal static CatPartyEmoji CatParty2 = new("cat_party_2", 1200608971145355327);
            internal static CatPartyEmoji CatParty3 = new("cat_party_3", 1200609989488816249);
        }

        internal record CatMemeEmoji : Emoji
        {
            public CatMemeEmoji(string name, ulong id) : base(name, id)
            {
                AnimatedEmojis.KWiJishoMemeEmojis.Add(this);
            }
        }
        internal record CatPartyEmoji : Emoji
        {
            public CatPartyEmoji(string name, ulong id) : base(name, id)
            {
                AnimatedEmojis.KWiJishoPartyEmojis.Add(this);
            }
        }
    }

    /// <summary>
    /// Class responsible for creating and handling custom Discord emojis.
    /// </summary>
    internal record Emoji
    {
        internal string Name { get; private set; }

        internal ulong Id { get; private set; }

        internal string Code { get; private set; }

        internal Emoji(string name, ulong id)
        {
            Name = name;
            Id = id;
            Code = $"<a:{name}:{id}>";

            Emojis.AnimatedEmojis.KWiJishoEmojis.Add(this);
        }

        public override string ToString() => Code;
    }
}
