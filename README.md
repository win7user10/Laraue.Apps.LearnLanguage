# Laraue.Apps.LearnLanguage

The telegram bot backend is built with https://github.com/win7user10/Laraue.Telegram.NET
The bot allows to learn translation of the top 5000 most used english words.
The bot can be found in Telegram here https://t.me/learn_lang_bot

## Features
### Quiz-mode
Helps to learn and repeat words

### Multi-language support
Current available pairs are en-ru, en-fr, en-ja

### Open-source
The bot could be forked and launched as a separated telegram bot

### Add new words easily
1. Edit [translations.json](src/Laraue.Apps.LearnLanguage.DataAccess/translations.json) and create new Migration
2. Create migration: cd src && dotnet ef migrations add MigrationName -p Laraue.Apps.LearnLanguage.DataAccess -s Laraue.Apps.LearnLanguage.Host -v
3. While next run translations will be added automatically

### Add new languages easily
1. Edit [languages.json](src/Laraue.Apps.LearnLanguage.DataAccess/languages.json) and create new Migration
2. Add translations manually or use Laraue.Apps.LearnLanguage.AutoTranslator which will use local AI [Ollama](https://ollama.com)
to fill translations.

## Local run (long-pooling mode)
1. Create new telegram bot with @BotFather and get a token
2. Create file appsettings.Development.json in the project Laraue.Apps.LearnLanguage.Host and fill it with taken telegram token
```json
{
    "Telegram": {
        "Token": "tg_token"
    }
}
```
3. Run Laraue.Apps.LearnLanguage.Host. Write `/start` to your bot it should answer.