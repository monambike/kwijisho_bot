// VARIÁVEIS
// Tradução
var translationJSON = `{
	"pt":{
		"lang": "[pt]Eu agora falo português!",
		"site": "[pt]Conheça o meu desenvolvedor: https://github.com/monambike",
		"hey":{
			"1": "[pt]eai! Espera.. você disse '",
			"2": "', agora pouco?"
		}
	},

	"en":{
		"lang": "[en]Now I speak english!",
		"site": "[en]Conheça o meu desenvolvedor: https://github.com/monambike",
		"hey":{
			"1": "[en]eai! Espera.. você disse '",
			"2": "', agora pouco?"
		}
	},

	"es":{
		"lang": "[es]Yo ahora hablo español!",
		"site": "[es]Conheça o meu desenvolvedor: https://github.com/monambike",
		"hey":{
			"1": "[es]eai! Espera.. você disse '",
			"2": "', agora pouco?"
		}
	},

	"jp":{
		"lang": "今日本語を話せる！",
		"site": "Conheça o meu desenvolvedor: https://github.com/monambike",
		"hey":{
			"1": "eai! Espera.. você disse '",
			"2": "', agora pouco?"
		}
	}
}`;
translationJS = JSON.parse(translationJSON);
botLang = "pt";
// Contador
var i = 0;
// BOT
const Discord = require("discord.js");
const bot = new Discord.Client();
const token = "NzM3NTM1ODQ4MTAyMzYzMjU5.Xx-xyA.ALivCZ6TyjvekWlZ5tSoLzlFW2o";
var PREFIX = "!";
// Layout
var name = "Vinícius Gabriel";
var fullName = "Vinícius Gabriel Marques de Melo";
var GitHub = "https://github.com/monambike";
var purple = "#8C1EFF";

bot.on("ready", function(name){
	console.log("Obrigada! Agora estou viva e atualizadaa turururu");
});

const info = new Discord.MessageEmbed()
	.setColor(purple)
	.setTitle('Meu Github!')
	.setURL(GitHub)
	.setAuthor(name, 'https://i.imgur.com/wSTFkRM.png', 'https://discord.js.org')
	.setDescription('Visite meu GitHub para ver mais projetos como esse!')
	.attachFiles(['resources/v-icon.png'])
	.setThumbnail('attachment://resources/v-icon.png')
	.setTimestamp()
	.setFooter(fullName + ' ('+ name +')');

const commands = new Discord.MessageEmbed()
	.setColor(purple)
	.setTitle('COMANDOS')
	.setDescription("Essa são as coisinhas que sei fazer! Não esqueça de colocar '!' antes de comando hein!")
	.addFields(
		{ name: 'lang (idioma)', value: 'Escolhe um idioma. Os idiomas que eu sei falar são português (pt), inglês (en), espanhol (es) e japonês (jp).' },
		{ name: 'site', value: 'Mostro o meu site.' },
		{ name: 'hey (mensagem)', value: 'Teste e descubra! C:' },
		{ name: 'info', value: 'Mostro algumas informações.' },
		{ name: 'commands', value: 'Abro a lista de comandos.' },
	);

bot.on("message", function(msg){
	let args = msg.content.substring(PREFIX.length).split(" ");
	var validLanguage = args[1] === "pt" || args[1] === "en" || args[1] === "es" || args[1] === "jp";

	if(msg.content.startsWith("!")){
		switch(args[0]){
			case "lang":
				if(validLanguage){
					msg.channel.send(translationJS[args[1]]["lang"]);
					botLang = args[1];
					return;
				}else{
					msg.channel.send("Poxa... eu ainda não sei falar '" + msg.content.substring(6) + "' ainda...");
				}
				break;
			case "site":
				msg.channel.send(translationJS[botLang]["site"]);
				break;
			case "hey":
				msg.reply(translationJS[botLang]["hey"][1] + msg.content + translationJS[botLang]["hey"][2]);
				break;
			case "info":
				msg.channel.send(info);
				break;
			case "commands":
				msg.channel.send(commands);
				break;
			default:
				msg.channel.send("Putz cara... ;~; que vergonha... Desculpa mas não sei fazer isso... Se quiser saber o que eu sei fazer digite '!commands'.");
				break;
		}		
	}
})

bot.login(token);