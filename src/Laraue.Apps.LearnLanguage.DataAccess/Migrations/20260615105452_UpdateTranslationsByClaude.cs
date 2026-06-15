using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laraue.Apps.LearnLanguage.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTranslationsByClaude : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 10L },
                column: "transcription",
                value: "no ue ni");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 14L },
                column: "transcription",
                value: "juéduì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 15L },
                column: "transcription",
                value: "juéduì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 16L },
                column: "transcription",
                value: "ab-sor-bay");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 17L },
                column: "transcription",
                value: "chūshōteki");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 19L },
                column: "transcription",
                value: "yutakasa");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 20L },
                column: "transcription",
                value: "nüèdài");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 21L },
                column: "transcription",
                value: "nüè dài");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 22L },
                column: "transcription",
                value: "xué shù de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 23L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "universitaire", "y-ni-vɛʁ-si-tɛʁ" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 23L },
                column: "transcription",
                value: "ah-kah-deh-mee-ker");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 27L },
                column: "transcription",
                value: "ukeireru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 31L },
                column: "transcription",
                value: "akusesu suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 32L },
                column: "transcription",
                value: "dostupnyy");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 32L },
                column: "transcription",
                value: "akusesu kanō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 33L },
                column: "transcription",
                value: "ak-si-dã");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 33L },
                column: "transcription",
                value: "durghaṭanā");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 34L },
                column: "transcription",
                value: "kah-swahl-men-te");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 36L },
                column: "transcription",
                value: "shukuhaku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 37L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "付き添う", "tsukisou" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 37L },
                column: "transcription",
                value: "péibàn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 38L },
                column: "transcription",
                value: "tassei suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 39L },
                column: "transcription",
                value: "dostizheniye");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 39L },
                column: "transcription",
                value: "tassei");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 40L },
                column: "transcription",
                value: "tekigō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 41L },
                column: "transcription",
                value: "ni yoru to");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 49L },
                column: "transcription",
                value: "chikuseki suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 50L },
                column: "transcription",
                value: "chikuseki");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 51L },
                column: "transcription",
                value: "zhǔnquèxìng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 51L },
                column: "transcription",
                value: "saṭīkatā");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 53L },
                column: "transcription",
                value: "seikaku ni");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 54L },
                column: "transcription",
                value: "a-kü-za-sjɔ̃");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 55L },
                column: "transcription",
                value: "hinan suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 55L },
                column: "transcription",
                value: "ah-koo-sar");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 56L },
                column: "transcription",
                value: "a-kü-ze");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 56L },
                column: "transcription",
                value: "hikoku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 56L },
                column: "transcription",
                value: "bèigào");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 57L },
                column: "transcription",
                value: "tassei suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 57L },
                column: "transcription",
                value: "lo-grahr");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 58L },
                column: "transcription",
                value: "tassei");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 62L },
                column: "transcription",
                value: "kakutoku suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 63L },
                column: "transcription",
                value: "kakutoku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 63L },
                column: "transcription",
                value: "ah-dkee-see-syon");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 65L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "поперёк", "paperyok" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 70L },
                column: "transcription",
                value: "kidō suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 71L },
                column: "transcription",
                value: "jīhuó");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 73L },
                column: "transcription",
                value: "mi-li-tɑ̃");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 75L },
                column: "transcription",
                value: "yǎnyuán");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 77L },
                column: "transcription",
                value: "jissai no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 77L },
                column: "transcription",
                value: "shíjì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 78L },
                column: "transcription",
                value: "shíjìshàng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 79L },
                column: "transcription",
                value: "surudoi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 83L },
                column: "transcription",
                value: "dobavit'");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 83L },
                column: "transcription",
                value: "a-zhoo-tay");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 83L },
                column: "transcription",
                value: "ah-nyah-deer");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 86L },
                column: "transcription",
                value: "tsuika no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 254L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "беспокойный", "bespokoynyy" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 262L },
                column: "transcription",
                value: "tomokaku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 263L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "任何地方", "rèn hé dì fāng" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 263L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "कहीं भी", "kahin bhi" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 265L },
                column: "transcription",
                value: "betsubetsu ni");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 265L },
                column: "transcription",
                value: "alag");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 267L },
                column: "transcription",
                value: "ayamaru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 267L },
                column: "transcription",
                value: "dào qiàn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 268L },
                column: "transcription",
                value: "sha-zai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 270L },
                column: "transcription",
                value: "sō-chi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 272L },
                column: "transcription",
                value: "xiǎn rán");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 273L },
                column: "transcription",
                value: "uttae");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 276L },
                column: "transcription",
                value: "a-pa-rɛtr");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 276L },
                column: "transcription",
                value: "arawareru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 277L },
                column: "transcription",
                value: "wài biǎo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 279L },
                column: "transcription",
                value: "hakushu suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 281L },
                column: "transcription",
                value: "tekiyō kanō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 281L },
                column: "transcription",
                value: "an-vent-bar");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 282L },
                column: "transcription",
                value: "kɑ̃-di-da");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 284L },
                column: "transcription",
                value: "mōshikomu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 285L },
                column: "transcription",
                value: "ninmei suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 285L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "ernennen", "er-nen-nen" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 289L },
                column: "transcription",
                value: "ah-sehr-kah-myen-toh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 289L },
                column: "transcription",
                value: "fāng fǎ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 508L },
                column: "transcription",
                value: "zokusuru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 508L },
                column: "transcription",
                value: "peɾteneˈθeɾ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 508L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "संबंधित होना", "sambandhit honā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 520L },
                column: "transcription",
                value: "ri-eki");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 522L },
                column: "transcription",
                value: "magatta");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 522L },
                column: "transcription",
                value: "muṛā");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 523L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "そばに", "soba ni" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 525L },
                column: "transcription",
                value: "kuwaete");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 525L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "के अलावा", "ke alāvā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 535L },
                column: "transcription",
                value: "ma ni");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 535L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "en medio", "en ˈmeðjo" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 536L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "の間に", "no aida ni" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 539L },
                column: "transcription",
                value: "piān jiàn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 539L },
                column: "transcription",
                value: "pūrvāgrah");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 541L },
                column: "transcription",
                value: "li-si-ta-syon");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 542L },
                column: "transcription",
                value: "nyūsatsu suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 544L },
                column: "transcription",
                value: "zìxíngchē");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 545L },
                column: "transcription",
                value: "seikyūsho");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 547L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "mil millones", "mil miˈʎones" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 548L },
                column: "transcription",
                value: "kon-te-ne-dor");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 549L },
                column: "transcription",
                value: "svyazyvat'");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 551L },
                column: "transcription",
                value: "seibutsu-gaku-teki na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 557L },
                column: "transcription",
                value: "zhǔjiào");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 567L },
                column: "transcription",
                value: "semeru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 568L },
                column: "transcription",
                value: "kūhaku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 569L },
                column: "transcription",
                value: "kūhaku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 569L },
                column: "transcription",
                value: "kòngbái");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 570L },
                column: "transcription",
                value: "mōfu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 571L },
                column: "transcription",
                value: "bàozhà");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 572L },
                column: "transcription",
                value: "bàozhà");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 573L },
                column: "transcription",
                value: "shukketsu suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 577L },
                column: "transcription",
                value: "shukufuku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 578L },
                column: "transcription",
                value: "mōmoku no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 580L },
                column: "transcription",
                value: "zǔzhǐ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 581L },
                column: "transcription",
                value: "blog");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 589L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "hospedar", "os-pe-dar" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 591L },
                column: "transcription",
                value: "fune");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 594L },
                column: "transcription",
                value: "daitan");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 595L },
                column: "transcription",
                value: "zhàdàn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 598L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "vínculo", "ˈbiŋkulo" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 598L },
                column: "transcription",
                value: "zhàiquàn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 600L },
                column: "transcription",
                value: "bōnasu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 602L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "reservar", "re-ser-var" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 609L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "border", "bɔʁde" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 609L },
                column: "transcription",
                value: "rinsetsu suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 617L },
                column: "transcription",
                value: "nayamaseru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 618L },
                column: "transcription",
                value: "botoru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 620L },
                column: "transcription",
                value: "soko");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 622L },
                column: "transcription",
                value: "shibarareta");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 624L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "бант", "bant" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 624L },
                column: "transcription",
                value: "nø");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 624L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "蝶結び", "chōmusubi" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 624L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "lazo", "ˈlaso" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 624L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "Schleife", "ˈʃlaɪfə" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 626L },
                column: "transcription",
                value: "ta-son");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 751L },
                column: "transcription",
                value: "kā-pe-tto");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 752L },
                column: "transcription",
                value: "basha");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 754L },
                column: "transcription",
                value: "nesti");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 754L },
                column: "transcription",
                value: "hakobu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 754L },
                column: "transcription",
                value: "xiédài");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 756L },
                column: "transcription",
                value: "vyrezat'");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 756L },
                column: "transcription",
                value: "horu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 759L },
                column: "transcription",
                value: "dǔ chǎng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 760L },
                column: "transcription",
                value: "yǎnyuán zhènróng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 761L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "werfen", "ver-fen" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 766L },
                column: "transcription",
                value: "katarogu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 767L },
                column: "transcription",
                value: "ulov");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 767L },
                column: "transcription",
                value: "hokaku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 768L },
                column: "transcription",
                value: "toraeru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 769L },
                column: "transcription",
                value: "kategori");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 770L },
                column: "transcription",
                value: "motenasu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 771L },
                column: "transcription",
                value: "jiā-chù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 773L },
                column: "transcription",
                value: "hikiokosu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 773L },
                column: "transcription",
                value: "fɛɐ̯ˈʔuːɐ̯zaxn̩");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 774L },
                column: "transcription",
                value: "ˈfoːɐ̯zɪçt");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 774L },
                column: "transcription",
                value: "sāvdhānī");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 775L },
                column: "transcription",
                value: "ɐstɐˈroʐnɨj");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 775L },
                column: "transcription",
                value: "ˈfoːɐ̯zɪçtɪç");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 777L },
                column: "transcription",
                value: "shī dī");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 779L },
                column: "transcription",
                value: "tenjō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 779L },
                column: "transcription",
                value: "de-ke");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 780L },
                column: "transcription",
                value: "iwau");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 783L },
                column: "transcription",
                value: "se-lyl");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 784L },
                column: "transcription",
                value: "mùdì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 786L },
                column: "transcription",
                value: "zhōng-yāng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 788L },
                column: "transcription",
                value: "sen-trar");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 789L },
                column: "transcription",
                value: "yahr-hun-dert");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 790L },
                column: "transcription",
                value: "shikiten");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 791L },
                column: "transcription",
                value: "ɐprʲɪdʲɪˈlʲɵnːɨj");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 791L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "確かな", "tashika na" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 792L },
                column: "transcription",
                value: "tashika ni");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 793L },
                column: "transcription",
                value: "kakushin");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 794L },
                column: "transcription",
                value: "zhèng-shū");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 796L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "つなぐ", "tsunagu" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 798L },
                column: "transcription",
                value: "suwaraseru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 798L },
                column: "transcription",
                value: "nom-brar");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 798L },
                column: "transcription",
                value: "adhyakshata karna");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 799L },
                column: "transcription",
                value: "for-zit-tsen-de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 801L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "चुनौती देना", "chunautī denā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 802L },
                column: "transcription",
                value: "ahn-shprukhs-fol");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 804L },
                column: "transcription",
                value: "chanpion");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 805L },
                column: "transcription",
                value: "senshuken");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 807L },
                column: "transcription",
                value: "fer-en-de-rung");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 807L },
                column: "transcription",
                value: "biàn-huà");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 809L },
                column: "transcription",
                value: "pín-dào");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 810L },
                column: "transcription",
                value: "hùn luàn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 810L },
                column: "transcription",
                value: "arājaktā");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 814L },
                column: "transcription",
                value: "kaɾakteˈɾistika");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 815L },
                column: "transcription",
                value: "ka-rak-te-ri-thar");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 815L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "charakterisieren", "kha-rak-te-ri-zee-ren" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 815L },
                column: "transcription",
                value: "varnan karna");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 816L },
                column: "transcription",
                value: "akyzasjɔ̃");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 817L },
                column: "transcription",
                value: "zaryazhat'");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 817L },
                column: "transcription",
                value: "kokuhatsu suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 818L },
                column: "transcription",
                value: "jizen");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 818L },
                column: "transcription",
                value: "cí shàn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 819L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "charme", "ʃaʁm" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 822L },
                column: "transcription",
                value: "huì zhì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 824L },
                column: "transcription",
                value: "per-se-ku-syon");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 824L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "पीछा", "pīchhā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 825L },
                column: "transcription",
                value: "ou");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 825L },
                column: "transcription",
                value: "fer-fol-gen");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 825L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "पीछा करना", "pīchhā karnā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 827L },
                column: "transcription",
                value: "hanasu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 829L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "安く", "yasuku" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 830L },
                column: "transcription",
                value: "zuru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 830L },
                column: "transcription",
                value: "shvin-del");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 831L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "tricher", "tree-shay" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 831L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "ごまかす", "gomakasu" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1001L },
                column: "transcription",
                value: "hoshō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 1002L },
                column: "transcription",
                value: "sorevnovat'sya");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 1002L },
                column: "transcription",
                value: "kɔ̃kuʁiʁ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1002L },
                column: "transcription",
                value: "kisou");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 1002L },
                column: "transcription",
                value: "vet-ai-fern");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1002L },
                column: "transcription",
                value: "jìngzhēng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1004L },
                column: "transcription",
                value: "yūnō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 1004L },
                column: "transcription",
                value: "kɔmpeˈtɛnt");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1004L },
                column: "transcription",
                value: "yogya");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 1005L },
                column: "transcription",
                value: "sorevnovaniye");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 1005L },
                column: "transcription",
                value: "vet-be-verp");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1005L },
                column: "transcription",
                value: "jìngzhēng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1006L },
                column: "transcription",
                value: "jìngzhēng de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1011L },
                column: "transcription",
                value: "oginau");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 1011L },
                column: "transcription",
                value: "kom-ple-men-tar");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1014L },
                column: "transcription",
                value: "wánquán");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1019L },
                column: "transcription",
                value: "junshu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1021L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "合併症", "gappeishō" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1253L },
                column: "transcription",
                value: "norikumiin");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1259L },
                column: "transcription",
                value: "hihyōka");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1262L },
                column: "transcription",
                value: "hihan");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1262L },
                column: "transcription",
                value: "pīpíng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1263L },
                column: "transcription",
                value: "pīpíng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1272L },
                column: "transcription",
                value: "miseisei no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1272L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "कच्चा", "kachchā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1273L },
                column: "transcription",
                value: "zankoku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1273L },
                column: "transcription",
                value: "cánkù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1283L },
                column: "transcription",
                value: "saibai suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1289L },
                column: "transcription",
                value: "naosu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1290L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "好奇心", "hàoqíxīn" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1291L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "好奇心の強い", "kōkishin no tsuyoi" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 1291L },
                column: "transcription",
                value: "ku-ri-o-so");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1294L },
                column: "transcription",
                value: "dāngqián de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1297L },
                column: "transcription",
                value: "pāṭhyakram");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1300L },
                column: "transcription",
                value: "mageru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1301L },
                column: "transcription",
                value: "magatta");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 1301L },
                column: "transcription",
                value: "kur-bo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 1309L },
                column: "transcription",
                value: "sikl");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 1309L },
                column: "transcription",
                value: "see-kloh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1310L },
                column: "transcription",
                value: "junkan suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1311L },
                column: "transcription",
                value: "hiniku na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1327L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "हिम्मत करना", "himmat karnā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 1334L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "sortir avec", "sɔʁtiʁ avɛk" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 1334L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "salir con", "sa-leer kon" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1338L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "死んだ", "shinda" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1356L },
                column: "transcription",
                value: "kettei");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1357L },
                column: "transcription",
                value: "ishi kettei");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1363L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "拒绝", "jùjué" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1363L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "अस्वीकार करना", "asvīkār karnā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1366L },
                column: "transcription",
                value: "genshō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 1370L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "акт", "akt" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1370L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "証書", "shōsho" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 1370L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "escritura", "es-kree-too-rah" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1377L },
                column: "transcription",
                value: "jībài");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1377L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "हराना", "harānā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1378L },
                column: "transcription",
                value: "kekkan");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1378L },
                column: "transcription",
                value: "quēxiàn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1383L },
                column: "transcription",
                value: "ketsubō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1383L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "缺乏", "quēfá" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1383L },
                column: "transcription",
                value: "kamī");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 1389L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "défier", "de.fje" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 1400L },
                column: "transcription",
                value: "vostorg");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 1403L },
                column: "transcription",
                value: "en-tre-gar");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1404L },
                column: "transcription",
                value: "haitatsu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1413L },
                column: "transcription",
                value: "hinan suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1418L },
                column: "transcription",
                value: "shuppatsu suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1419L },
                column: "transcription",
                value: "busho");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 1419L },
                column: "transcription",
                value: "ahp-tai-loong");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1421L },
                column: "transcription",
                value: "yīlài");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1421L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "निर्भर होना", "nirbhar honā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 1429L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "déprimé", "depʁime" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1432L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "वंचित करना", "vanchit karnā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1435L },
                column: "transcription",
                value: "dōshutsu suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1442L },
                column: "transcription",
                value: "atai suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1466L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "हिरासत", "hirāsat" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1469L },
                column: "transcription",
                value: "kettei suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1484L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "हुक्म देना", "hukm denā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 1492L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "différencier", "difeʁɑ̃sje" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1503L },
                column: "transcription",
                value: "hitasu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 1517L },
                column: "transcription",
                value: "nedostatok");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1521L },
                column: "transcription",
                value: "shīwàng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1522L },
                column: "transcription",
                value: "shīwàng de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1524L },
                column: "transcription",
                value: "shīwàng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1529L },
                column: "transcription",
                value: "jiěgù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 1531L },
                column: "transcription",
                value: "raskryvat'");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1533L },
                column: "transcription",
                value: "waribiki");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1534L },
                column: "transcription",
                value: "waribiku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1535L },
                column: "transcription",
                value: "quàn tuì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1536L },
                column: "transcription",
                value: "giron");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1540L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "差別", "sabetsu" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1541L },
                column: "transcription",
                value: "giron suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1547L },
                column: "transcription",
                value: "ken'o");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1549L },
                column: "transcription",
                value: "kaiko suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1549L },
                column: "transcription",
                value: "jiěgù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1550L },
                column: "transcription",
                value: "jiěgù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 1552L },
                column: "transcription",
                value: "vytesnyat'");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1556L },
                column: "transcription",
                value: "shobun suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1558L },
                column: "transcription",
                value: "arasou");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1559L },
                column: "transcription",
                value: "dǎrǎo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1560L },
                column: "transcription",
                value: "pòhuài");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1561L },
                column: "transcription",
                value: "tokeru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1561L },
                column: "transcription",
                value: "róngjiě");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1564L },
                column: "transcription",
                value: "dokutoku na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1565L },
                column: "transcription",
                value: "kubetsu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1566L },
                column: "transcription",
                value: "dokutoku na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1567L },
                column: "transcription",
                value: "kubetsu suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1568L },
                column: "transcription",
                value: "yugameru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1577L },
                column: "transcription",
                value: "qiánshuǐ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1581L },
                column: "transcription",
                value: "zhuǎnyí");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1586L },
                column: "transcription",
                value: "líhūn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1587L },
                column: "transcription",
                value: "líhūn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 1594L },
                column: "transcription",
                value: "dokumentirovat'");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1601L },
                column: "transcription",
                value: "zhīpèi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1603L },
                column: "transcription",
                value: "zhīpèi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 1605L },
                column: "transcription",
                value: "pozhertvovaniye");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1622L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "楼下", "lóu xià" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1625L },
                column: "transcription",
                value: "shinai chūshinbu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1626L },
                column: "transcription",
                value: "xiàngxià");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1629L },
                column: "transcription",
                value: "sōkō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1633L },
                column: "transcription",
                value: "xìjù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 1641L },
                column: "transcription",
                value: "odevat'");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1641L },
                column: "transcription",
                value: "kiru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1642L },
                column: "transcription",
                value: "kikazatta");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1651L },
                column: "transcription",
                value: "dī");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 1656L },
                column: "transcription",
                value: "baraban");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1657L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "नशे में", "nashe mein" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 1681L },
                column: "transcription",
                value: "zarabatyvat'");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1681L },
                column: "transcription",
                value: "zhuàn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1685L },
                column: "transcription",
                value: "qīngsōng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1712L },
                column: "transcription",
                value: "yǒuxiào");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1713L },
                column: "transcription",
                value: "yǒuxiào de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1714L },
                column: "transcription",
                value: "yǒuxiào xìng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1729L },
                column: "transcription",
                value: "kōrei no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1730L },
                column: "transcription",
                value: "erabu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1739L },
                column: "transcription",
                value: "yuánsù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1742L },
                column: "transcription",
                value: "takameru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1745L },
                column: "transcription",
                value: "haijo suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1746L },
                column: "transcription",
                value: "jīngyīng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1750L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "メールする", "mēru suru" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1752L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "शर्मिंदा", "sharminda" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1755L },
                column: "transcription",
                value: "taishikan");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1756L },
                column: "transcription",
                value: "qiànrù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1757L },
                column: "transcription",
                value: "tǐxiàn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1759L },
                column: "transcription",
                value: "shutsugen suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1760L },
                column: "transcription",
                value: "shutsugen");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1762L },
                column: "transcription",
                value: "hōshutsu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1764L },
                column: "transcription",
                value: "bhāvanātmak");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1765L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "情绪上", "qíngxù shàng" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1765L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "भावनात्मक रूप से", "bhāvanātmak rūp se" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1766L },
                column: "transcription",
                value: "qiángdiào");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1767L },
                column: "transcription",
                value: "qiángdiào");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1777L },
                column: "transcription",
                value: "qǐyòng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1778L },
                column: "transcription",
                value: "seitei suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1779L },
                column: "transcription",
                value: "hōgan suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1781L },
                column: "transcription",
                value: "au");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1782L },
                column: "transcription",
                value: "hagemasu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1785L },
                column: "transcription",
                value: "jiéshù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1790L },
                column: "transcription",
                value: "suishō suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1791L },
                column: "transcription",
                value: "suisen");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1794L },
                column: "transcription",
                value: "néngliàng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1797L },
                column: "transcription",
                value: "cānyù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1798L },
                column: "transcription",
                value: "kon'yaku-chū no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1799L },
                column: "transcription",
                value: "kon'yaku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 1804L },
                column: "transcription",
                value: "a-me-ljo-re");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1804L },
                column: "transcription",
                value: "tígāo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1810L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "十分", "jūbun" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 1810L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "suficiente", "su-fi-θjen-te" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 1810L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "genug", "ge-nuːk" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1810L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "足够", "zúgòu" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1810L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "पर्याप्त", "paryaapt" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1811L },
                column: "transcription",
                value: "toiawaseru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1812L },
                column: "transcription",
                value: "toiawase");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1816L },
                column: "transcription",
                value: "quèbǎo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1822L },
                column: "transcription",
                value: "rèqíng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1824L },
                column: "transcription",
                value: "rèqíng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1837L },
                column: "transcription",
                value: "byōdō na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1838L },
                column: "transcription",
                value: "byōdō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1839L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "बराबर करना", "barābar karnā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1840L },
                column: "transcription",
                value: "byōdō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1841L },
                column: "transcription",
                value: "byōdō ni");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 1846L },
                column: "transcription",
                value: "ekivalɑ̃");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1846L },
                column: "transcription",
                value: "sōtō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1872L },
                column: "transcription",
                value: "hitoshii");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 1872L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "uniforme", "u-ni-for-me" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 1872L },
                column: "transcription",
                value: "glaɪç");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1872L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "बराबर", "barābar" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 1877L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "déjà", "deʒa" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 1877L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "alguna vez", "al-gu-na bes" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1917L },
                column: "text",
                value: "独家");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2002L },
                column: "transcription",
                value: "shippai suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2003L },
                column: "transcription",
                value: "neudavshiysya");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2003L },
                column: "transcription",
                value: "shippai shita");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2003L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "gescheitert", "ge-shai-tert" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2004L },
                column: "transcription",
                value: "neudacha");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2004L },
                column: "transcription",
                value: "shippai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2013L },
                column: "transcription",
                value: "shoharat");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2016L },
                column: "transcription",
                value: "jiā tíng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2027L },
                column: "transcription",
                value: "tagayasu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2027L },
                column: "transcription",
                value: "virt-shaf-ten");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2029L },
                column: "transcription",
                value: "zemledeliye");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2032L },
                column: "transcription",
                value: "hayari no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2036L },
                column: "transcription",
                value: "futoi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2038L },
                column: "transcription",
                value: "smertel'nyy");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2038L },
                column: "transcription",
                value: "zhìmìng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2040L },
                column: "transcription",
                value: "chichi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2040L },
                column: "transcription",
                value: "fùqīn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2041L },
                column: "transcription",
                value: "ayamachi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2043L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "優遇する", "yūgū suru" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2045L },
                column: "transcription",
                value: "pasandīdā");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2046L },
                column: "transcription",
                value: "pasandīdā");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2048L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "fürchten", "fʏrç-ten" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2048L },
                column: "transcription",
                value: "hài pà");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2049L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "कारनामा", "kārnāmā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2052L },
                column: "transcription",
                value: "medatasaseru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2054L },
                column: "transcription",
                value: "liánbāng de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2060L },
                column: "transcription",
                value: "gǎn jué");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2063L },
                column: "transcription",
                value: "tovarishcheskiy");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2064L },
                column: "transcription",
                value: "vaip-lich");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2065L },
                column: "transcription",
                value: "nǚxìng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2066L },
                column: "transcription",
                value: "joseishugiteki na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 2066L },
                column: "transcription",
                value: "fe-mee-nees-tah");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 2067L },
                column: "transcription",
                value: "feh-mee-nees-tah");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2067L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "Feministin", "feh-mee-nis-tin" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2068L },
                column: "transcription",
                value: "fensu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2069L },
                column: "transcription",
                value: "jiérì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2075L },
                column: "transcription",
                value: "fikushon");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2075L },
                column: "transcription",
                value: "xiǎoshuō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2075L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "कल्पित कथा", "kalpit kathā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2076L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "野原", "nohara" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 2077L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "feroz", "feh-roth" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2081L },
                column: "transcription",
                value: "tatakai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2081L },
                column: "transcription",
                value: "kampf");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2082L },
                column: "transcription",
                value: "kempfen");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2086L },
                column: "transcription",
                value: "dah-tai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2087L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "подавать", "podavat'" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 2087L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "déposer", "de.po.ze" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2087L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "提出する", "teishutsu suru" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 2087L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "presentar", "pre-sen-tar" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2090L },
                column: "transcription",
                value: "satsuei suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2092L },
                column: "transcription",
                value: "guòlǜqì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2096L },
                column: "transcription",
                value: "zhōngyú");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2097L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "Finanzen", "fi-nahn-tsen" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2097L },
                column: "transcription",
                value: "jīnróng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2097L },
                column: "transcription",
                value: "vitt");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 2100L },
                column: "transcription",
                value: "en-kon-trar");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2104L },
                column: "transcription",
                value: "shobatsu suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2104L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "verdonnern", "fer-don-ern" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2107L },
                column: "transcription",
                value: "oeru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2107L },
                column: "transcription",
                value: "be-en-den");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2109L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "जलाना", "jalānā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2110L },
                column: "transcription",
                value: "ognestrel'noye oruzhiye");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2258L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "заправлять", "zapravlyat'" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2258L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "燃料を補給する", "nenryō o hokyū suru" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2258L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "加燃料", "jiā ránliào" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 2261L },
                column: "transcription",
                value: "a tɑ̃ plɛ̃");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 2261L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "a tiempo completo", "a ˈtjempo komˈpleto" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2261L },
                column: "transcription",
                value: "quánzhí");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2262L },
                column: "transcription",
                value: "furutaimu de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2262L },
                column: "transcription",
                value: "quánzhí de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2271L },
                column: "transcription",
                value: "kihonteki na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2272L },
                column: "transcription",
                value: "mūl rūp se");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2275L },
                column: "transcription",
                value: "sōgi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 2275L },
                column: "transcription",
                value: "fune'ral");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2275L },
                column: "transcription",
                value: "zànglǐ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2277L },
                column: "transcription",
                value: "kegawa");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 2278L },
                column: "transcription",
                value: "fyʁjø");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2280L },
                column: "transcription",
                value: "vai-ter");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2282L },
                column: "transcription",
                value: "cǐwài");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2284L },
                column: "transcription",
                value: "tsook-koonft");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2284L },
                column: "transcription",
                value: "wèilái");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2289L },
                column: "transcription",
                value: "gyanburu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2291L },
                column: "transcription",
                value: "yóuxì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2292L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "Bande", "ban-de" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2293L },
                column: "transcription",
                value: "sukima");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2298L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "集める", "atsumeru" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2298L },
                column: "transcription",
                value: "jùjí");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2299L },
                column: "transcription",
                value: "atsumari");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2303L },
                column: "transcription",
                value: "haguruma");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2304L },
                column: "transcription",
                value: "xìngbié");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 2305L },
                column: "transcription",
                value: "ʒɛn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2305L },
                column: "transcription",
                value: "idenshi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2309L },
                column: "transcription",
                value: "shìdài");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2312L },
                column: "transcription",
                value: "yíchuán de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 2314L },
                column: "transcription",
                value: "xenoˈθiðjo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2318L },
                column: "transcription",
                value: "vāstavik");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2322L },
                column: "transcription",
                value: "dédào");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2328L },
                column: "transcription",
                value: "onna no ko");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2335L },
                column: "transcription",
                value: "ichibetsu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2338L },
                column: "transcription",
                value: "chikyūgi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2348L },
                column: "transcription",
                value: "kin'iro");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2351L },
                column: "transcription",
                value: "hǎochù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2353L },
                column: "transcription",
                value: "wakare");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2354L },
                column: "transcription",
                value: "yasashisa");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2354L },
                column: "transcription",
                value: "shànliáng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2355L },
                column: "transcription",
                value: "shāngpǐn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2360L },
                column: "transcription",
                value: "chiji");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2363L },
                column: "transcription",
                value: "seiseki");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2372L },
                column: "transcription",
                value: "sofubo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2374L },
                column: "transcription",
                value: "shòuyǔ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2398L },
                column: "transcription",
                value: "nigiru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2399L },
                column: "transcription",
                value: "shípǐn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2400L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "気持ち悪い", "kimochi warui" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2409L },
                column: "transcription",
                value: "yóujī duìyuán");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2409L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "गुरिल्ला", "gurillā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2417L },
                column: "transcription",
                value: "zaiakukan");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2418L },
                column: "transcription",
                value: "zaiakukan no aru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2419L },
                column: "transcription",
                value: "jítā");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2422L },
                column: "transcription",
                value: "jiāhuo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2426L },
                column: "transcription",
                value: "uyamau");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2429L },
                column: "transcription",
                value: "yíbàn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 2501L },
                column: "transcription",
                value: "su");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2502L },
                column: "transcription",
                value: "yeyo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2507L },
                column: "transcription",
                value: "yeyo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2509L },
                column: "transcription",
                value: "tamerau");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2512L },
                column: "transcription",
                value: "yǐncáng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2513L },
                column: "transcription",
                value: "yǐncáng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2514L },
                column: "transcription",
                value: "děngjí zhìdù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 2515L },
                column: "transcription",
                value: "o");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2518L },
                column: "transcription",
                value: "chūmoku o atsumeru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2518L },
                column: "transcription",
                value: "prasiddh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2519L },
                column: "transcription",
                value: "hairaito");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2519L },
                column: "transcription",
                value: "zor");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2522L },
                column: "transcription",
                value: "kōsoku dōro");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2523L },
                column: "transcription",
                value: "omoshiroi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2524L },
                column: "transcription",
                value: "oka");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2526L },
                column: "transcription",
                value: "kare jishin");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2527L },
                column: "transcription",
                value: "tíshì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2529L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "腰", "koshi" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2530L },
                column: "transcription",
                value: "saiyō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2530L },
                column: "transcription",
                value: "gùyōng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2533L },
                column: "transcription",
                value: "zayn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2534L },
                column: "transcription",
                value: "rekishi gakusha");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2535L },
                column: "transcription",
                value: "lìshǐ de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2536L },
                column: "transcription",
                value: "lìshǐ de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2537L },
                column: "transcription",
                value: "lìshǐ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2540L },
                column: "transcription",
                value: "shumi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2542L },
                column: "transcription",
                value: "hoji");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2545L },
                column: "transcription",
                value: "jiàrì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2546L },
                column: "transcription",
                value: "kūdō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2548L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "家庭の", "katei no" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2549L },
                column: "transcription",
                value: "tsoo-rük");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2555L },
                column: "text",
                value: "誠実");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2556L },
                column: "transcription",
                value: "róngyù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2557L },
                column: "transcription",
                value: "tonaeru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2557L },
                column: "transcription",
                value: "eh-ren");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2559L },
                column: "transcription",
                value: "hikkakeru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2561L },
                column: "transcription",
                value: "nadeyatsya");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2563L },
                column: "transcription",
                value: "osoraku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2566L },
                column: "transcription",
                value: "hidoi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2566L },
                column: "transcription",
                value: "kěpà");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 2570L },
                column: "transcription",
                value: "an-fee-tree-on");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2570L },
                column: "transcription",
                value: "zhǔchírén");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2572L },
                column: "transcription",
                value: "hitojichi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2574L },
                column: "transcription",
                value: "tekii");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2576L },
                column: "transcription",
                value: "jiǔdiàn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2577L },
                column: "transcription",
                value: "xiǎoshí");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2579L },
                column: "transcription",
                value: "tomeru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2581L },
                column: "transcription",
                value: "zhilyo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2589L },
                column: "transcription",
                value: "kenkyo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2590L },
                column: "transcription",
                value: "yūmorasu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2593L },
                column: "transcription",
                value: "kue");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2596L },
                column: "transcription",
                value: "karu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2596L },
                column: "transcription",
                value: "shòuliè");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2600L },
                column: "transcription",
                value: "gǎnjǐn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2601L },
                column: "transcription",
                value: "kizutsuita");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2602L },
                column: "transcription",
                value: "téngtòng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2602L },
                column: "transcription",
                value: "dard");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2603L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "चोट पहुँचाना", "chot pahunchana" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2604L },
                column: "transcription",
                value: "otto");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2605L },
                column: "transcription",
                value: "qīng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 2606L },
                column: "transcription",
                value: "ee-poh-teh-sees");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2607L },
                column: "transcription",
                value: "main");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2609L },
                column: "transcription",
                value: "aiskreem");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2611L },
                column: "transcription",
                value: "ai-dī");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2612L },
                column: "transcription",
                value: "xiǎngfǎ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2615L },
                column: "transcription",
                value: "wánquán xiāngtóng de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2616L },
                column: "transcription",
                value: "shikibetsu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2616L },
                column: "transcription",
                value: "shēnfèn shíbié");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2617L },
                column: "transcription",
                value: "tokutei suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2619L },
                column: "transcription",
                value: "yìshí xíngtài de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2620L },
                column: "transcription",
                value: "yìshí xíngtài");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 2622L },
                column: "transcription",
                value: "see");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2622L },
                column: "transcription",
                value: "moshi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2624L },
                column: "transcription",
                value: "mushi suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2624L },
                column: "transcription",
                value: "hūlüè");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2624L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "अनदेखा करना", "andekha karna" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2628L },
                column: "transcription",
                value: "sakkaku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2630L },
                column: "transcription",
                value: "irasuto");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2632L },
                column: "transcription",
                value: "imēji");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 2633L },
                column: "transcription",
                value: "ee-ma-zhee-nehr");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2633L },
                column: "transcription",
                value: "sōzōjō no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2633L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "imaginär", "i-ma-gi-NEHR" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 2634L },
                column: "transcription",
                value: "imaxinaˈsjon");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2634L },
                column: "transcription",
                value: "xiǎngxiàng lì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 2635L },
                column: "transcription",
                value: "imaxiˈnar");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2636L },
                column: "transcription",
                value: "lìjí");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2637L },
                column: "transcription",
                value: "lìjí");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2639L },
                column: "transcription",
                value: "imin");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2641L },
                column: "transcription",
                value: "sashisematta");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2641L },
                column: "transcription",
                value: "pòzàiméijié");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2642L },
                column: "transcription",
                value: "men'eki no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2642L },
                column: "transcription",
                value: "miǎnyì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2646L },
                column: "transcription",
                value: "shíshī");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2647L },
                column: "transcription",
                value: "jissō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2647L },
                column: "transcription",
                value: "shíshī");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2649L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "संकेत करना", "sanket karna" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2650L },
                column: "transcription",
                value: "yunyū");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2651L },
                column: "transcription",
                value: "yunyū suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2652L },
                column: "transcription",
                value: "zhòngyàoxìng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2654L },
                column: "transcription",
                value: "kasu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2656L },
                column: "transcription",
                value: "kanshin saseru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2656L },
                column: "transcription",
                value: "dǎdòng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2657L },
                column: "transcription",
                value: "yìnxiàng shēnkè");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2658L },
                column: "transcription",
                value: "yìnxiàng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2659L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "印象的な", "inshōteki na" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2660L },
                column: "transcription",
                value: "jiānjìn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2661L },
                column: "transcription",
                value: "jiānjìn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2667L },
                column: "transcription",
                value: "bùzú");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2671L },
                column: "transcription",
                value: "ghatna");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2672L },
                column: "transcription",
                value: "shìjiàn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2674L },
                column: "transcription",
                value: "bāokuò");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2675L },
                column: "transcription",
                value: "fukumareta");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2676L },
                column: "transcription",
                value: "fukumu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2677L },
                column: "transcription",
                value: "hōsetsu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2678L },
                column: "transcription",
                value: "shōurù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2682L },
                column: "transcription",
                value: "fuyasu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2683L },
                column: "transcription",
                value: "masumasu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2683L },
                column: "transcription",
                value: "rìyì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2685L },
                column: "transcription",
                value: "shinjirarenai hodo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2685L },
                column: "transcription",
                value: "nányǐ zhìxìn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2686L },
                column: "transcription",
                value: "kaburu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2687L },
                column: "transcription",
                value: "tashika ni");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2688L },
                column: "transcription",
                value: "dúlì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2689L },
                column: "transcription",
                value: "dokuritsu no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2689L },
                column: "transcription",
                value: "dúlì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2690L },
                column: "transcription",
                value: "sakuin");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2690L },
                column: "transcription",
                value: "suǒyǐn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2691L },
                column: "transcription",
                value: "shimesu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2692L },
                column: "transcription",
                value: "jìxiàng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2693L },
                column: "transcription",
                value: "zhǐbiāo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2694L },
                column: "transcription",
                value: "kiso");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2696L },
                column: "transcription",
                value: "kansetsuteki na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2696L },
                column: "transcription",
                value: "apratyaksh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 2697L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "individuel", "ɛ̃dividɥɛl" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2697L },
                column: "transcription",
                value: "kobetsu no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 2697L },
                column: "transcription",
                value: "in-di-bi-dwahl");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2697L },
                column: "transcription",
                value: "gèrén");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2698L },
                column: "transcription",
                value: "gèrén");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2699L },
                column: "transcription",
                value: "shìnèi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2700L },
                column: "transcription",
                value: "shìnèi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2701L },
                column: "transcription",
                value: "yūhatsu suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2701L },
                column: "transcription",
                value: "yòudǎo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2702L },
                column: "transcription",
                value: "amanjiru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2704L },
                column: "transcription",
                value: "gōngyè");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2704L },
                column: "transcription",
                value: "udyog");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2705L },
                column: "transcription",
                value: "fuheidō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2705L },
                column: "transcription",
                value: "oon-glykh-hite");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2707L },
                column: "transcription",
                value: "hitsuzenteki ni");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 2707L },
                column: "transcription",
                value: "inevitablemente");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2708L },
                column: "transcription",
                value: "akumei takai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2708L },
                column: "transcription",
                value: "chòumíng zhāozhù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2709L },
                column: "transcription",
                value: "mladenets");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2709L },
                column: "transcription",
                value: "yīng'ér");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2712L },
                column: "transcription",
                value: "suisoku suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2714L },
                column: "transcription",
                value: "shiiru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2714L },
                column: "transcription",
                value: "qiángjiā");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2715L },
                column: "transcription",
                value: "yǐngxiǎng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2716L },
                column: "transcription",
                value: "yǐngxiǎng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2718L },
                column: "transcription",
                value: "in-for-mah-tsi-ohn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2718L },
                column: "transcription",
                value: "xìnxī");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2719L },
                column: "transcription",
                value: "shiraseru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2720L },
                column: "transcription",
                value: "kajuaru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2721L },
                column: "transcription",
                value: "In-for-ma-tsi-ohn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 2722L },
                column: "transcription",
                value: "ɛ̃fʁastʁyktyʁ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2723L },
                column: "transcription",
                value: "zairyō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2723L },
                column: "transcription",
                value: "tsoo-taht");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2724L },
                column: "transcription",
                value: "jūmín");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2725L },
                column: "transcription",
                value: "koyū no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2726L },
                column: "transcription",
                value: "jìchéng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2727L },
                column: "transcription",
                value: "yokusei suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2727L },
                column: "transcription",
                value: "yìzhì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2728L },
                column: "transcription",
                value: "zuìchū");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2729L },
                column: "transcription",
                value: "tōsho");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2729L },
                column: "transcription",
                value: "zuìchū");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 2730L },
                column: "transcription",
                value: "in-i-syar");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2730L },
                column: "transcription",
                value: "kāishǐ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2732L },
                column: "transcription",
                value: "chūsha suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2732L },
                column: "transcription",
                value: "zhùshè");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2733L },
                column: "transcription",
                value: "zhùshè");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2734L },
                column: "transcription",
                value: "chot pahunchana");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2735L },
                column: "transcription",
                value: "shòushāng de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2740L },
                column: "transcription",
                value: "uchi no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2741L },
                column: "transcription",
                value: "muzai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2742L },
                column: "transcription",
                value: "chuàngxīn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2744L },
                column: "transcription",
                value: "nyūryoku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2745L },
                column: "transcription",
                value: "toiawase");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2745L },
                column: "transcription",
                value: "ahn-frah-geh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2745L },
                column: "transcription",
                value: "xúnwèn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2750L },
                column: "transcription",
                value: "lǐmiàn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 2753L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "persona enterada", "per'sona ente'rada" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2754L },
                column: "transcription",
                value: "dōsatsuryoku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2763L },
                column: "transcription",
                value: "shílì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2769L },
                column: "transcription",
                value: "uchrezhdeniye");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 2769L },
                column: "transcription",
                value: "ɛ̃stitysjɔ̃");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2769L },
                column: "transcription",
                value: "kikan");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2769L },
                column: "transcription",
                value: "in-sti-tu-tsi-ohn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2770L },
                column: "transcription",
                value: "zhìdù de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2772L },
                column: "transcription",
                value: "nirdesh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2774L },
                column: "transcription",
                value: "gakki");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2781L },
                column: "transcription",
                value: "pos-tup-leh-nee-ye");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2781L },
                column: "transcription",
                value: "sesshu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2782L },
                column: "transcription",
                value: "bùkě fēngē de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2784L },
                column: "transcription",
                value: "in-teh-gri-ro-van-nyy");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2788L },
                column: "transcription",
                value: "chishikijin");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2790L },
                column: "transcription",
                value: "kashikoi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2790L },
                column: "transcription",
                value: "in-teh-lee-gent");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2791L },
                column: "transcription",
                value: "ito suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2793L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "intensiv", "in-ten-ziːf" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2793L },
                column: "transcription",
                value: "qiángliè");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2794L },
                column: "transcription",
                value: "usilivat'");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2794L },
                column: "transcription",
                value: "gekika suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2795L },
                column: "transcription",
                value: "kyōdo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2796L },
                column: "transcription",
                value: "mìjí");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2799L },
                column: "transcription",
                value: "sōgo sayō suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2799L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "interagieren", "in-ter-a-gee-ren" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2801L },
                column: "transcription",
                value: "jiāohù shì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2801L },
                column: "transcription",
                value: "samvādātmak");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2804L },
                column: "transcription",
                value: "zainteresovannyy");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2805L },
                column: "transcription",
                value: "interesnyy");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2807L },
                column: "transcription",
                value: "kanshō suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2808L },
                column: "transcription",
                value: "kanshō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 2809L },
                column: "transcription",
                value: "pro-vee-zwar");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2810L },
                column: "transcription",
                value: "uchigawa no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2810L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "innere", "ˈɪnərə" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2811L },
                column: "transcription",
                value: "in-en-raum");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 3001L },
                column: "transcription",
                value: "ki-te");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3008L },
                column: "transcription",
                value: "yíchǎn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3009L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "合法的な", "gōhō-teki na" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3009L },
                column: "transcription",
                value: "héfǎ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3010L },
                column: "transcription",
                value: "legenda");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3012L },
                column: "transcription",
                value: "rippō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 3012L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "विधान", "vidhān" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3015L },
                column: "transcription",
                value: "seitō na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3015L },
                column: "transcription",
                value: "héfǎ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3017L },
                column: "transcription",
                value: "níngméng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3023L },
                column: "transcription",
                value: "sukunaku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3030L },
                column: "transcription",
                value: "tegami");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3046L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "пожизненный", "pozhiznennyy" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3061L },
                column: "transcription",
                value: "zhī");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3067L },
                column: "transcription",
                value: "páiliè");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3068L },
                column: "transcription",
                value: "narabi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3068L },
                column: "transcription",
                value: "zhènróng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3074L },
                column: "transcription",
                value: "kuchibiru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3074L },
                column: "transcription",
                value: "zuǐchún");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3075L },
                column: "transcription",
                value: "zhidkiy");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3075L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "液体の", "ekitai no" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3076L },
                column: "transcription",
                value: "zhidkost'");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3076L },
                column: "transcription",
                value: "ekitai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3076L },
                column: "transcription",
                value: "yètǐ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3091L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "немного", "nemnogo" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 3091L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "peu", "pø" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3091L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "少し", "sukoshi" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3091L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "poco", "po-ko" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 3091L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "wenig", "veh-nikh" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3091L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "少许", "shǎoxǔ" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 3091L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "थोड़ा", "thoṛā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3135L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "montón", "mon-ton" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 3135L },
                column: "transcription",
                value: "ain tail");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 3167L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "courrier", "ku-ʁje" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3170L },
                column: "transcription",
                value: "hondo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3170L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "continente", "kon-tee-nen-teh" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3177L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "especialidad", "es-pe-thya-li-dad" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 3177L },
                column: "transcription",
                value: "haupt-fakh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 3179L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "marque", "maʁk" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3179L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "marca", "mar-ka" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3200L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "многие", "mnogiye" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 3200L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "beaucoup", "bo-ku" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3200L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "多く", "ōku" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3200L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "muchos", "moo-chos" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 3200L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "viele", "fee-leh" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3200L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "许多", "xǔduō" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 3200L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "कई", "kaī" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3205L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "marcha", "mar-cha" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3208L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "маргинальный", "marginal'nyy" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 3209L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "marin", "maˈʁiːn" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 3224L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "नरसंहार", "narsanhār" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3232L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "aparearse", "a-pa-re-ar-se" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 3233L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "materiell", "ma-te-ri-ell" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3233L },
                column: "transcription",
                value: "cái zhì de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 3246L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "können", "kœ-nen" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3253L },
                column: "transcription",
                value: "yǒu yìyì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3254L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "средство", "sredstvo" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 3254L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "moyen", "mwa.jɛ̃" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3254L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "手段", "shudan" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 3254L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "Mittel", "ˈmɪtl̩" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3254L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "手段", "shǒuduàn" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 3254L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "साधन", "saadhan" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3255L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "mientras tanto", "ˈmjentras ˈtanto" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 3255L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "währenddessen", "ˈvɛːʁəntˌdɛsn̩" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3256L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "mientras tanto", "ˈmjentras ˈtanto" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3256L },
                column: "transcription",
                value: "yǔ cǐ tóng shí");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3258L },
                column: "transcription",
                value: "hakaru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3259L },
                column: "transcription",
                value: "cèliáng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3261L },
                column: "transcription",
                value: "jīxièshī");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3262L },
                column: "transcription",
                value: "kikaiteki na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3262L },
                column: "transcription",
                value: "jīxiè de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 3262L },
                column: "transcription",
                value: "yāntrik");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3265L },
                column: "transcription",
                value: "media");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3265L },
                column: "transcription",
                value: "méitǐ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 3266L },
                column: "transcription",
                value: "me-di-tsi-nish");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3266L },
                column: "transcription",
                value: "yīxué de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3268L },
                column: "transcription",
                value: "kusuri");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3269L },
                column: "transcription",
                value: "zhōngshìjì de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3271L },
                column: "transcription",
                value: "zhōngděng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 3272L },
                column: "transcription",
                value: "mwa.jɛ̃");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3272L },
                column: "transcription",
                value: "baitai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3272L },
                column: "transcription",
                value: "méijiè");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 3274L },
                column: "transcription",
                value: "ʁe.y.njɔ̃");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 3274L },
                column: "transcription",
                value: "baithak");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3277L },
                column: "transcription",
                value: "chéngyuán");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3278L },
                column: "transcription",
                value: "kaiin");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3278L },
                column: "transcription",
                value: "mem-bre-see-ah");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 3278L },
                column: "transcription",
                value: "mit-gleed-shaft");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3280L },
                column: "transcription",
                value: "kaikoroku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3281L },
                column: "transcription",
                value: "omoidebukai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3281L },
                column: "transcription",
                value: "in-ol-vee-dah-ble");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 3284L },
                column: "transcription",
                value: "gai-stikh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3284L },
                column: "transcription",
                value: "jīngshén de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3285L },
                column: "transcription",
                value: "genkyū");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 3285L },
                column: "transcription",
                value: "er-ve-nung");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3285L },
                column: "transcription",
                value: "tíjí");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3286L },
                column: "transcription",
                value: "genkyū suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3286L },
                column: "transcription",
                value: "tíjí");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3287L },
                column: "transcription",
                value: "mentā");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3288L },
                column: "transcription",
                value: "càidān");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 3288L },
                column: "transcription",
                value: "menoo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3290L },
                column: "transcription",
                value: "mee-seh-ree-kor-dee-ah");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3290L },
                column: "transcription",
                value: "liánmǐn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 3290L },
                column: "transcription",
                value: "dayā");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3291L },
                column: "transcription",
                value: "jǐnjǐn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3292L },
                column: "transcription",
                value: "sim-ple-men-te");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3292L },
                column: "transcription",
                value: "jǐnjǐn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3296L },
                column: "transcription",
                value: "hùnluàn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3299L },
                column: "transcription",
                value: "in'yu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3299L },
                column: "transcription",
                value: "yǐnyù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3301L },
                column: "transcription",
                value: "hōhōron");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3301L },
                column: "transcription",
                value: "fāngfǎlùn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3305L },
                column: "transcription",
                value: "polnoch'");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3305L },
                column: "transcription",
                value: "mayonaka");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3307L },
                column: "transcription",
                value: "kamoshirenai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 3307L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "शायद", "shāyad" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3308L },
                column: "transcription",
                value: "ijū");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 3309L },
                column: "transcription",
                value: "zanft");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3309L },
                column: "transcription",
                value: "wēnhé");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 3311L },
                column: "transcription",
                value: "mi.li.tɑ̃");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3311L },
                column: "transcription",
                value: "kageki na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3311L },
                column: "transcription",
                value: "be-lee-heh-ran-te");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3311L },
                column: "transcription",
                value: "jījìn de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 3312L },
                column: "transcription",
                value: "mi.li.tɑ̃");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3312L },
                column: "transcription",
                value: "kagekiha");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3312L },
                column: "transcription",
                value: "jījìn fènzǐ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 3312L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "उग्रवादी", "ugravādī" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 3313L },
                column: "transcription",
                value: "mi.li.tɛʁ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3313L },
                column: "transcription",
                value: "jūnshì de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3314L },
                column: "transcription",
                value: "jūnduì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3317L },
                column: "transcription",
                value: "melnitsa");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3359L },
                column: "transcription",
                value: "wēnhé");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 3501L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "créneau", "kʁeˈno" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3501L },
                column: "transcription",
                value: "nitchi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3501L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "nicho", "nee-cho" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3522L },
                column: "transcription",
                value: "shōgo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3523L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "も…ない", "mo…nai" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3535L },
                column: "transcription",
                value: "chomei-na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3545L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "печально известный", "pechal'no izvestnyy" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3545L },
                column: "transcription",
                value: "akumyō takai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3546L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "novedoso", "no-veh-do-so" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3547L },
                column: "transcription",
                value: "xiǎo shuō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 3559L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "crèche", "kʁɛʃ" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3562L },
                column: "transcription",
                value: "yíngyǎng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3567L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "возражать", "vozrazhat'" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3567L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "objetar", "ob-he-tar" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3572L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "義務づける", "gimuzukeru" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3576L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "執着する", "shūchaku suru" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3580L },
                column: "transcription",
                value: "meihaku na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3581L },
                column: "transcription",
                value: "xiǎnrán");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3582L },
                column: "transcription",
                value: "kikai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3583L },
                column: "transcription",
                value: "tokiori");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3584L },
                column: "transcription",
                value: "inogda");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3584L },
                column: "transcription",
                value: "tokidoki");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3597L },
                column: "transcription",
                value: "okoraseru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3599L },
                column: "transcription",
                value: "fukai na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 3599L },
                column: "transcription",
                value: "ākrāmak");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3601L },
                column: "transcription",
                value: "mōshideru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3606L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "役人", "yakunin" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3611L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "bien", "byen" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3618L },
                column: "transcription",
                value: "céngjīng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3619L },
                column: "transcription",
                value: "céngjīng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3620L },
                column: "transcription",
                value: "ichi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3622L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "человек", "chelovek" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 3622L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "on", "ɔ̃" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3622L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "人", "hito" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 3622L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "man", "man" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3622L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "人", "rén" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 3622L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "कोई", "koī" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3624L },
                column: "transcription",
                value: "tamanegi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3634L },
                column: "transcription",
                value: "gējù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3635L },
                column: "transcription",
                value: "sōsa suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3636L },
                column: "transcription",
                value: "shujutsu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3642L },
                column: "transcription",
                value: "hantai suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3649L },
                column: "transcription",
                value: "erabu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3649L },
                column: "transcription",
                value: "xuǎnzé");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3653L },
                column: "transcription",
                value: "xuǎnxiàng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3655L },
                column: "transcription",
                value: "kōtō no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3759L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "парковать", "parkovat'" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 3759L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "garer", "ga-ray" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3759L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "駐車する", "chūsha suru" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3759L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "aparcar", "ah-par-kar" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3762L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "议会的", "yìhuì de" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3770L },
                column: "transcription",
                value: "tokutei no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3777L },
                column: "transcription",
                value: "proyti");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 3777L },
                column: "transcription",
                value: "pase");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3777L },
                column: "transcription",
                value: "watasu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3778L },
                column: "transcription",
                value: "tsūro");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3783L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "受動的な", "judō-teki na" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3797L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "пациент", "patsient" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 3797L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "Patient", "pa-tsi-ent" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3797L },
                column: "transcription",
                value: "bìngrén");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 3797L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "मरीज़", "marīz" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3798L },
                column: "transcription",
                value: "xúnluó");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3799L },
                column: "transcription",
                value: "xúnluó");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3801L },
                column: "transcription",
                value: "patān");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3804L },
                column: "transcription",
                value: "chingin");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3806L },
                column: "transcription",
                value: "shiharai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3813L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "ручка", "ruchka" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3814L },
                column: "transcription",
                value: "chéngfá");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3815L },
                column: "transcription",
                value: "ka-ran-dash");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3818L },
                column: "transcription",
                value: "hitobito");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3819L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "pimienta", "piˈmjenta" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3829L },
                column: "transcription",
                value: "enjiru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3830L },
                column: "transcription",
                value: "pafōmansu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3830L },
                column: "transcription",
                value: "biǎoyǎn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3832L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "期間", "kikan" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3833L },
                column: "transcription",
                value: "yǒngjiǔ de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 3833L },
                column: "transcription",
                value: "sthāyī");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3834L },
                column: "transcription",
                value: "yǒngjiǔ de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3839L },
                column: "transcription",
                value: "nebari-zuyoi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3842L },
                column: "transcription",
                value: "xìnggé");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 3842L },
                column: "transcription",
                value: "vyaktitva");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3843L },
                column: "transcription",
                value: "qīnzì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3846L },
                column: "transcription",
                value: "settoku suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3850L },
                column: "transcription",
                value: "dankai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 3850L },
                column: "transcription",
                value: "fah-zeh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3850L },
                column: "transcription",
                value: "jiēduàn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3851L },
                column: "transcription",
                value: "genshō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3853L },
                column: "transcription",
                value: "tetsugaku-teki na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3853L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "哲学的", "zhéxué de" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3854L },
                column: "transcription",
                value: "zhéxué");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3855L },
                column: "transcription",
                value: "diànhuà");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3859L },
                column: "transcription",
                value: "pāizhào");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3860L },
                column: "transcription",
                value: "shèyǐng shī");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3861L },
                column: "transcription",
                value: "shèyǐng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3863L },
                column: "transcription",
                value: "butsuri-teki na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3864L },
                column: "transcription",
                value: "yīshēng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3867L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "выбор", "vybor" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 3867L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "choix", "shwa" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3867L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "選択", "sentaku" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3867L },
                column: "transcription",
                value: "xuǎnzé");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4009L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "वरीयता", "varīyatā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 4016L },
                column: "transcription",
                value: "PREE-mi-um");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4030L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "司会する", "shikai suru" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4032L },
                column: "transcription",
                value: "zǒngtǒng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4032L },
                column: "transcription",
                value: "rāṣṭrapati");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 4056L },
                column: "transcription",
                value: "asnovnoy");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4056L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "最高の", "saikō no" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4060L },
                column: "transcription",
                value: "xiàozhǎng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4071L },
                column: "transcription",
                value: "sī rén de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4076L },
                column: "transcription",
                value: "pro-BAH-bleh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4077L },
                column: "transcription",
                value: "pro-bah-ble-MEN-teh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4082L },
                column: "transcription",
                value: "tejun");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4082L },
                column: "transcription",
                value: "pra-kri-yaa");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4107L },
                column: "transcription",
                value: "biān chéng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4108L },
                column: "transcription",
                value: "kaaryakram");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4109L },
                column: "transcription",
                value: "biān chéng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4111L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "आगे बढ़ना", "aage badhna" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 4112L },
                column: "transcription",
                value: "pʁogʁesist");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4115L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "投影する", "tōei suru" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4115L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "proyectar", "proh-yek-tar" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4116L },
                column: "transcription",
                value: "tóuyǐng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4117L },
                column: "transcription",
                value: "hair-for-shtekh-ent");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4119L },
                column: "transcription",
                value: "fer-shpreh-hen");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4120L },
                column: "transcription",
                value: "āśājanak");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 4123L },
                column: "transcription",
                value: "ɛ̃site");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4123L },
                column: "transcription",
                value: "unagasu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 4125L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "prononcé", "pʁɔnɔ̃se" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4125L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "pronunciado", "pro-noon-thee-AH-do" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4125L },
                column: "transcription",
                value: "ows-ge-shpro-khen");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4127L },
                column: "transcription",
                value: "proh-pah-gahn-dah");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4128L },
                column: "transcription",
                value: "tekisetsu na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4129L },
                column: "transcription",
                value: "tadashiku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4136L },
                column: "transcription",
                value: "qǐsù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4137L },
                column: "transcription",
                value: "abhiyojak");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4147L },
                column: "transcription",
                value: "pradarshankaaree");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4151L },
                column: "transcription",
                value: "teikyō suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4151L },
                column: "transcription",
                value: "tígōng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4154L },
                column: "transcription",
                value: "gōngyìng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4163L },
                column: "transcription",
                value: "shuppan");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4165L },
                column: "transcription",
                value: "shuppan suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4165L },
                column: "transcription",
                value: "fābù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4173L },
                column: "transcription",
                value: "naguru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4176L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "punk", "punk" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4181L },
                column: "transcription",
                value: "poo-ree ta-rah se");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4185L },
                column: "transcription",
                value: "anusaran karnaa");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4192L },
                column: "transcription",
                value: "kvalifiˈtsiːɐt");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4195L },
                column: "transcription",
                value: "kan-tee-dad");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4196L },
                column: "transcription",
                value: "jìdù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4197L },
                column: "transcription",
                value: "joō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4197L },
                column: "transcription",
                value: "kœːnɪɡɪn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4201L },
                column: "transcription",
                value: "xún wèn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4202L },
                column: "transcription",
                value: "wènjuàn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4203L },
                column: "transcription",
                value: "duìliè");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4211L },
                column: "transcription",
                value: "wariate");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4214L },
                column: "transcription",
                value: "yǐn yòng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 4216L },
                column: "transcription",
                value: "sorevnovat'sya");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4223L },
                column: "transcription",
                value: "fúshè");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4224L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "कट्टरपंथी", "kattarpanthī" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 4227L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "raid", "ʁɛd" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4228L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "asaltar", "ah-sahl-tahr" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4229L },
                column: "transcription",
                value: "tiěguǐ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4229L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "पटरी", "patrī" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4233L },
                column: "transcription",
                value: "ageru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4234L },
                column: "transcription",
                value: "koond-geh-boong");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4236L },
                column: "transcription",
                value: "tsoo-feh-lig");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4237L },
                column: "transcription",
                value: "han'i");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4237L },
                column: "transcription",
                value: "raikh-vai-te");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4238L },
                column: "transcription",
                value: "oyobu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4238L },
                column: "transcription",
                value: "ghoomnaa");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4241L },
                column: "transcription",
                value: "klah-see-fee-kah-syon");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4245L },
                column: "transcription",
                value: "kyūsoku ni");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4247L },
                column: "transcription",
                value: "hěn shǎo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4249L },
                column: "transcription",
                value: "zats");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4251L },
                column: "transcription",
                value: "mushiro");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4251L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "más bien", "mas bjen" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4252L },
                column: "transcription",
                value: "reṭiṅg");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4256L },
                column: "transcription",
                value: "shè xiàn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4259L },
                column: "transcription",
                value: "hannō suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4260L },
                column: "transcription",
                value: "han'nō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4260L },
                column: "transcription",
                value: "fǎn yìng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4262L },
                column: "transcription",
                value: "dokusha");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4263L },
                column: "transcription",
                value: "qīng yì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4267L },
                column: "transcription",
                value: "xiànshí de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4268L },
                column: "transcription",
                value: "xiànshí");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4277L },
                column: "transcription",
                value: "hélǐ de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4283L },
                column: "transcription",
                value: "omoidasu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4295L },
                column: "transcription",
                value: "ninshiki suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4296L },
                column: "transcription",
                value: "suishō suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4302L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "再集計する", "saishūkei suru" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4324L },
                column: "transcription",
                value: "kotowaru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4338L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "定期地", "dìngqī de" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4347L },
                column: "transcription",
                value: "jùjué");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4348L },
                column: "transcription",
                value: "jùjué");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4377L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "驚くべき", "odorokubeki" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 4378L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "замечательно", "zamechatel'no" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 4378L },
                column: "text",
                value: "remarquablement");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4378L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "驚くほどに", "odoroku hodo ni" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4382L },
                column: "transcription",
                value: "rimaindā");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4388L },
                column: "transcription",
                value: "prasiddh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4392L },
                column: "transcription",
                value: "reh-pah-rah-toor");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4394L },
                column: "transcription",
                value: "kurikaeshi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4399L },
                column: "transcription",
                value: "huí fù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 4423L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "напоминать", "napaminát'" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4423L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "似る", "niru" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4426L },
                column: "transcription",
                value: "yù dìng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4428L },
                column: "transcription",
                value: "teitaku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4428L },
                column: "transcription",
                value: "VOH-noong");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4433L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "辞任する", "jinin suru" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4435L },
                column: "transcription",
                value: "dǐkàng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4436L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "抵抗する", "teikō suru" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4486L },
                column: "transcription",
                value: "mukuiru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4501L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "disturbio", "dis-tur-bjo" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4502L },
                column: "transcription",
                value: "sī liè");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4506L },
                column: "transcription",
                value: "mào xiǎn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4507L },
                column: "transcription",
                value: "mào xiǎn de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4520L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "varilla", "bah-REE-yah" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4520L },
                column: "transcription",
                value: "gùn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4521L },
                column: "transcription",
                value: "yakuwari");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4538L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "चारों ओर", "chaaron or" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4539L },
                column: "transcription",
                value: "lù xiàn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4540L },
                column: "transcription",
                value: "reh-gel-mai-sikh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4545L },
                column: "transcription",
                value: "xiàng jiāo de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4546L },
                column: "transcription",
                value: "xiàng jiāo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4574L },
                column: "transcription",
                value: "shuǐ shǒu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4575L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "Heiliger", "HAI-li-ger" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4579L },
                column: "transcription",
                value: "cù xiāo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4581L },
                column: "transcription",
                value: "xiāng tóng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4601L },
                column: "transcription",
                value: "chǒu wén");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4603L },
                column: "transcription",
                value: "daranā");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4607L },
                column: "transcription",
                value: "qíng jǐng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4608L },
                column: "transcription",
                value: "chǎng jǐng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4616L },
                column: "transcription",
                value: "kē xué");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4617L },
                column: "transcription",
                value: "kē xué de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4627L },
                column: "text",
                value: "anzeigen");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4628L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "Untersuchung", "ʊntɛʁˈzuːxʊŋ" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4631L },
                column: "transcription",
                value: "kyakuhon");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4651L },
                column: "transcription",
                value: "AHP-shnit");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 4654L },
                column: "transcription",
                value: "bezopásnyy");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4654L },
                column: "transcription",
                value: "anzen na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 4655L },
                column: "transcription",
                value: "obespechivat'");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4655L },
                column: "transcription",
                value: "kakuho suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4661L },
                column: "transcription",
                value: "hǎo xiàng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4673L },
                column: "transcription",
                value: "fā sòng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4679L },
                column: "transcription",
                value: "mǐn gǎn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4680L },
                column: "transcription",
                value: "mǐn gǎn xìng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4700L },
                column: "transcription",
                value: "drishya");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4710L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "严重地", "yán zhòng de" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4712L },
                column: "transcription",
                value: "seiteki");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4733L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "透き通った", "sukitōtta" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4752L },
                column: "transcription",
                value: "satsuei");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4760L },
                column: "transcription",
                value: "tanki");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4772L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "कंधे उचकाना", "kandhe uchakānā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4780L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "आह भरना", "āh bharnā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4781L },
                column: "transcription",
                value: "shikai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 4788L },
                column: "transcription",
                value: "ɛ̃pɔʁtɑ̃");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4789L },
                column: "transcription",
                value: "sig-nee-fee-kah-tee-vah-men-teh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 4793L },
                column: "transcription",
                value: "glupyy");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4796L },
                column: "transcription",
                value: "siˈmilar");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 4797L },
                column: "transcription",
                value: "skhodstvo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 4797L },
                column: "transcription",
                value: "similityd");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4797L },
                column: "transcription",
                value: "ruijisei");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4798L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "de manera similar", "de ma-ne-ra si-mi-lar" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4810L },
                column: "transcription",
                value: "kashu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4811L },
                column: "transcription",
                value: "el kahn-toh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4812L },
                column: "transcription",
                value: "solˈteɾo/a");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4831L },
                column: "transcription",
                value: "ah-bee-lee-doh-soh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4832L },
                column: "transcription",
                value: "hifu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4835L },
                column: "transcription",
                value: "tóugǔ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4835L },
                column: "transcription",
                value: "khopṛī");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4837L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "叩きつける", "tatakitsukeru" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4844L },
                column: "transcription",
                value: "piàn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4855L },
                column: "transcription",
                value: "màn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 4856L },
                column: "transcription",
                value: "zamedlyat'");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4856L },
                column: "transcription",
                value: "okuraseru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4857L },
                column: "transcription",
                value: "yukkuri");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4858L },
                column: "transcription",
                value: "xiǎo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4862L },
                column: "transcription",
                value: "geh-rookh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4862L },
                column: "transcription",
                value: "qìwèi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4864L },
                column: "transcription",
                value: "egao");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4865L },
                column: "transcription",
                value: "egao ni suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4867L },
                column: "transcription",
                value: "dhūmrapān karnā");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4878L },
                column: "transcription",
                value: "sekken");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4879L },
                column: "transcription",
                value: "ahs-sen-dehr");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4881L },
                column: "transcription",
                value: "shè-huì de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4883L },
                column: "transcription",
                value: "shè-huì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4886L },
                column: "transcription",
                value: "ruǎnjiàn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4892L },
                column: "transcription",
                value: "lǜshī");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4896L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "单独的", "dāndú de" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4897L },
                column: "transcription",
                value: "dúzòu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4897L },
                column: "transcription",
                value: "ekal");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4903L },
                column: "transcription",
                value: "deh al-goo-nah mah-neh-rah");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 4907L },
                column: "transcription",
                value: "ee-nahg-dah");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4907L },
                column: "transcription",
                value: "tokidoki");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 4916L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "Pardon !", "pahr-dohn" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4916L },
                column: "transcription",
                value: "oh yeh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4919L },
                column: "transcription",
                value: "tamashii");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4919L },
                column: "transcription",
                value: "línghún");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4929L },
                column: "transcription",
                value: "sam-prah-bhu-tā");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 4933L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "s'étendre sur", "setɑ̃dʁ syʁ" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4940L },
                column: "transcription",
                value: "vishéshagya");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4941L },
                column: "transcription",
                value: "zhuānjiā");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4941L },
                column: "transcription",
                value: "vishéshagya");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4942L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "विशेषज्ञ बनना", "vishéshagya bannā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4943L },
                column: "transcription",
                value: "zhuānyè");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4943L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "विशिष्ट", "vishisht" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4944L },
                column: "transcription",
                value: "es-PEH-syeh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4945L },
                column: "transcription",
                value: "tokutei no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 4947L },
                column: "transcription",
                value: "spe.si.fi.ka.sjɔ̃");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4949L },
                column: "transcription",
                value: "mwes-trah");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4953L },
                column: "transcription",
                value: "pínpǔ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4957L },
                column: "transcription",
                value: "sùdù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4969L },
                column: "transcription",
                value: "ghūrṇan");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 4971L },
                column: "transcription",
                value: "pozvonochnik");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4971L },
                column: "transcription",
                value: "VIR-bel-zoy-le");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4973L },
                column: "transcription",
                value: "ādhyātmik");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 4974L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "rancune", "rɑ̃kyn" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4974L },
                column: "transcription",
                value: "akui");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4974L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "Boshaftigkeit", "boh-shahf-tikh-kait" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4974L },
                column: "transcription",
                value: "tiraskār");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4980L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "प्रवक्ता", "pravaktā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4981L },
                column: "transcription",
                value: "nǚ fāyán rén");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4989L },
                column: "transcription",
                value: "pahchānnā");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 4991L },
                column: "transcription",
                value: "suprug/supruga");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4991L },
                column: "transcription",
                value: "jīvansāthī");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4998L },
                column: "transcription",
                value: "duìwu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5000L },
                column: "transcription",
                value: "varg");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 5009L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "ставить", "stavit'" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 5009L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "mettre en scène", "metʁ ɑ̃ sɛn" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5009L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "上演する", "jōen suru" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5011L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "हिस्सेदारी", "hissedārī" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5012L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "स्टॉल", "sṭŏl" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5013L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "टिकट", "ṭikaṭ" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 5021L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "destacar", "des-tah-kar" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 5021L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "auszeichnen", "ows-tsaikh-nen" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 5027L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "anímico", "a-NEE-mee-koh" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 5027L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "gefühlsmäßig", "ge-fühls-meh-sikh" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5027L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "情绪的", "qíngxù de" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5043L },
                column: "transcription",
                value: "kyū na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5044L },
                column: "transcription",
                value: "sōjū suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5044L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "चलाना", "chalānā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 5046L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "происходить", "proiskhodit'" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 5046L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "provenir", "pʁɔvəniʁ" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5046L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "由来する", "yurai suru" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5050L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "छड़ी", "chhaṛī" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 5052L },
                column: "transcription",
                value: "ˈkleːbʁɪç");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5053L },
                column: "transcription",
                value: "katai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 5083L },
                column: "transcription",
                value: "podcherkivat'");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5098L },
                column: "transcription",
                value: "jié gòu de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5109L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "ठोकर खाना", "ṭhokar khānā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5126L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "स्थानापन्न", "sthānāpann" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5127L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "बदलना", "badalnā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 5128L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "Ersetzung", "ɛɐ̯ˈzɛtsʊŋ" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5260L },
                column: "transcription",
                value: "nerau");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5269L },
                column: "transcription",
                value: "sikhānā");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5299L },
                column: "transcription",
                value: "ninki");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5302L },
                column: "transcription",
                value: "zhōngduān de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5303L },
                column: "transcription",
                value: "zhōngduān");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5303L },
                column: "transcription",
                value: "ṭarminal");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5312L },
                column: "transcription",
                value: "kǒngbù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 5334L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "не используется", "ne ispol'zuyetsya" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5334L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "定冠詞", "teikanshi" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5334L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "该", "gāi" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5334L },
                column: "transcription",
                value: "yah");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5335L },
                column: "transcription",
                value: "gekijō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 5340L },
                column: "transcription",
                value: "ø");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5343L },
                column: "transcription",
                value: "soshite");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5352L },
                column: "transcription",
                value: "shitagatte");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5363L },
                column: "transcription",
                value: "kǒu kě");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5372L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "けれども", "keredomo" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5374L },
                column: "transcription",
                value: "kangaesaserareru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5381L },
                column: "transcription",
                value: "shikii");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5384L },
                column: "transcription",
                value: "nodo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5387L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "至る所で", "itaru tokoro de" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5390L },
                column: "transcription",
                value: "oyayubi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 5391L },
                column: "transcription",
                value: "zhødi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5405L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "計る", "hakaru" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5410L },
                column: "transcription",
                value: "ṭip");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5414L },
                column: "transcription",
                value: "biāotí");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5415L },
                column: "transcription",
                value: "nazukeru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5424L },
                column: "transcription",
                value: "kan'yō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 5436L },
                column: "transcription",
                value: "osi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5442L },
                column: "transcription",
                value: "wadai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5445L },
                column: "transcription",
                value: "nageru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5450L },
                column: "transcription",
                value: "chùmō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5454L },
                column: "transcription",
                value: "cān guān");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5456L },
                column: "transcription",
                value: "yóukè");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5456L },
                column: "transcription",
                value: "paryatak");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5481L },
                column: "transcription",
                value: "ressha");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5490L },
                column: "transcription",
                value: "kaeru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5499L },
                column: "transcription",
                value: "pārdarshī");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 5525L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "billion", "bee-yõ" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5530L },
                column: "transcription",
                value: "butai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 5530L },
                column: "transcription",
                value: "ˈtʁʊpə");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5530L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "टुकड़ी", "ṭukṛī" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5538L },
                column: "transcription",
                value: "hontō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5548L },
                column: "transcription",
                value: "maṅgalvār");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 5550L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "мелодия", "melódiya" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 5550L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "air", "ɛʁ" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 5550L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "melodía", "meloˈðia" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5560L },
                column: "transcription",
                value: "futago no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5577L },
                column: "transcription",
                value: "oji");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5578L },
                column: "transcription",
                value: "i-go-ko-chi ga wa-ru-i");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5591L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "अंडरवियर", "aṇḍarviyar" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 5599L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "к сожалению", "k sozhaleniyu" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5599L },
                column: "text",
                value: "残念ながら");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5606L },
                column: "transcription",
                value: "lián hé");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5609L },
                column: "transcription",
                value: "fuhenteki na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5611L },
                column: "transcription",
                value: "dàxué");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5612L },
                column: "transcription",
                value: "fumei");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5613L },
                column: "transcription",
                value: "chú fēi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5614L },
                column: "transcription",
                value: "ke viparīt");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5616L },
                column: "transcription",
                value: "fuyō na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5617L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "अप्रिय", "apriy" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5638L },
                column: "transcription",
                value: "toshi no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5638L },
                column: "transcription",
                value: "śahrī");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5639L },
                column: "transcription",
                value: "unagasu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5656L },
                column: "transcription",
                value: "zhēn kōng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5658L },
                column: "transcription",
                value: "yǒu xiào");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5659L },
                column: "transcription",
                value: "yǒu xiào xìng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5661L },
                column: "transcription",
                value: "yǒu jiàzhí");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5663L },
                column: "transcription",
                value: "píng gū");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5668L },
                column: "transcription",
                value: "biànhuà");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 5670L },
                column: "transcription",
                value: "raznoobraziye");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5672L },
                column: "transcription",
                value: "biànhuà");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5677L },
                column: "transcription",
                value: "màoxiǎn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5678L },
                column: "transcription",
                value: "màoxiǎn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5679L },
                column: "transcription",
                value: "chǎngdì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5680L },
                column: "transcription",
                value: "kōtō no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5686L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "垂直", "suichoku" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5686L },
                column: "transcription",
                value: "chuí zhí");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5689L },
                column: "transcription",
                value: "róngqì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5689L },
                column: "transcription",
                value: "jahāz");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5690L },
                column: "transcription",
                value: "taieki gunjin");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5690L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "पूर्व सैनिक", "pūrv sainik" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5692L },
                column: "transcription",
                value: "kě xíng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5694L },
                column: "transcription",
                value: "akuheki");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 5694L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "Laster", "ˈlastɐ" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5698L },
                column: "transcription",
                value: "bideo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5698L },
                column: "transcription",
                value: "shìpín");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5701L },
                column: "transcription",
                value: "shichōsha");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5705L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "उल्लंघन करना", "ullaṅghan karnā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 5706L },
                column: "transcription",
                value: "bjolaˈsjon");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5706L },
                column: "transcription",
                value: "ullaṅghan");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5708L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "暴力的", "bàolì de" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 5709L },
                column: "transcription",
                value: "biɾˈtwal");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5711L },
                column: "transcription",
                value: "bìngdú");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5711L },
                column: "transcription",
                value: "vāyras");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 5718L },
                column: "transcription",
                value: "bisuˈal");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5718L },
                column: "transcription",
                value: "shìjué de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5721L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "ボーカルの", "bōkaru no" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 5721L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "vocal", "boˈkal" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5731L },
                column: "transcription",
                value: "zeijakusei");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5731L },
                column: "transcription",
                value: "cuìruòxìng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5732L },
                column: "transcription",
                value: "cuìruò");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5734L },
                column: "transcription",
                value: "děngdài");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5735L },
                column: "transcription",
                value: "matsu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5735L },
                column: "transcription",
                value: "děngdài");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5738L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "सैर", "sair" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 5744L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "sala", "ˈsala" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5760L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "बर्बाद करना", "barbād karnā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5761L },
                column: "transcription",
                value: "udedokei");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5773L },
                column: "transcription",
                value: "tomi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5783L },
                column: "transcription",
                value: "kharpatvār");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5787L },
                column: "transcription",
                value: "hakaru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5790L },
                column: "transcription",
                value: "svāgat yogya");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5798L },
                column: "transcription",
                value: "ido");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5811L },
                column: "transcription",
                value: "xiǎomài");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5812L },
                column: "transcription",
                value: "sharin");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5818L },
                column: "text",
                value: "どこ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 5826L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "rato", "rah-toh" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 5828L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "взбивать", "vzbivat'" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5828L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "泡立てる", "awadateru" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 5828L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "batir", "bah-teer" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 5829L },
                column: "transcription",
                value: "soo-soo-rroh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 5840L },
                column: "transcription",
                value: "deh kyen");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5843L },
                column: "transcription",
                value: "guǎngfàn de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5846L },
                column: "transcription",
                value: "mibōjin");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5850L },
                column: "transcription",
                value: "yěshēng dòngwù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5851L },
                column: "transcription",
                value: "yuigon");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5853L },
                column: "transcription",
                value: "yorokonde");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5859L },
                column: "transcription",
                value: "khiḍkī");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 5862L },
                column: "transcription",
                value: "gah-nah-dor");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5867L },
                column: "transcription",
                value: "kashikoi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5897L },
                column: "transcription",
                value: "rúchóng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5904L },
                column: "transcription",
                value: "pūjā");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5905L },
                column: "transcription",
                value: "pūjā");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 5917L },
                column: "transcription",
                value: "ɑ̃.ba.le");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5926L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "आँगन", "āṅgan" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 5938L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "hervorbringen", "her-for-bring-en" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5938L },
                column: "transcription",
                value: "chǎnshēng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 5944L },
                column: "transcription",
                value: "too-yo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 5945L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "tú mismo", "too mees-moh" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 10L },
                column: "transcription",
                value: "noh-eh-noh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 14L },
                column: "transcription",
                value: "zhuéduì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 15L },
                column: "transcription",
                value: "zhuēduì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 16L },
                column: "transcription",
                value: "a-bor-bay");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 17L },
                column: "transcription",
                value: "a-bura-ku-teki");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 19L },
                column: "transcription",
                value: "yūka sa");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 20L },
                column: "transcription",
                value: "àobiē");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 21L },
                column: "transcription",
                value: "nyè dài");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 22L },
                column: "transcription",
                value: "shù-xué de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 23L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "cadre", "kah-drə" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 23L },
                column: "transcription",
                value: "ah-keh-deh-meer");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 27L },
                column: "transcription",
                value: "u-ke-i-nu-meru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 31L },
                column: "transcription",
                value: "ak-ku-e-su-ru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 32L },
                column: "transcription",
                value: "dosúpnıy");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 32L },
                column: "transcription",
                value: "akusesu puru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 33L },
                column: "transcription",
                value: "a-di-sã");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 33L },
                column: "transcription",
                value: "durgnaṭana");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 34L },
                column: "transcription",
                value: "kas-wah-len-te");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 36L },
                column: "transcription",
                value: "shū-gaku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 37L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "付き合う", "tsu-ku-nyau" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 37L },
                column: "transcription",
                value: "bái-pàn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 38L },
                column: "transcription",
                value: "tac-chuu suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 39L },
                column: "transcription",
                value: "dah-stih-nee-ye");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 39L },
                column: "transcription",
                value: "tachii");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 40L },
                column: "transcription",
                value: "ka-koo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 41L },
                column: "transcription",
                value: "ni yuu ni");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 49L },
                column: "transcription",
                value: "chūkuseki suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 50L },
                column: "transcription",
                value: "chūkisseki");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 51L },
                column: "transcription",
                value: "zhun-gwan-xing");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 51L },
                column: "transcription",
                value: "sa-tee-kah");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 53L },
                column: "transcription",
                value: "se-kak-ku-ni");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 54L },
                column: "transcription",
                value: "azy-syon");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 55L },
                column: "transcription",
                value: "hiannan suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 55L },
                column: "transcription",
                value: "ah-koo-zar");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 56L },
                column: "transcription",
                value: "azyke");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 56L },
                column: "transcription",
                value: "hoka");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 56L },
                column: "transcription",
                value: "bǐ gǔ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 57L },
                column: "transcription",
                value: "takat-su-ru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 57L },
                column: "transcription",
                value: "lo-grah");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 58L },
                column: "transcription",
                value: "tatsū");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 62L },
                column: "transcription",
                value: "ka-i-to-su-ru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 63L },
                column: "transcription",
                value: "ka-i");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 63L },
                column: "transcription",
                value: "ah-dee-see-oh-ne");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 65L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "наперерез", "nah-peer-yehz" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 70L },
                column: "transcription",
                value: "ka-i-do-su-ru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 71L },
                column: "transcription",
                value: "jee-huó");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 73L },
                column: "transcription",
                value: "miˈlɑ̃");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 75L },
                column: "transcription",
                value: "yán-yú");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 77L },
                column: "transcription",
                value: "jik-kai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 77L },
                column: "transcription",
                value: "shi-ji");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 78L },
                column: "transcription",
                value: "shi-ji-shí");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 79L },
                column: "transcription",
                value: "e-gui");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 83L },
                column: "transcription",
                value: "dadat'");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 83L },
                column: "transcription",
                value: "zho-tay");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 83L },
                column: "transcription",
                value: "ahn-theer");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 86L },
                column: "transcription",
                value: "tsu-ka-no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 254L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "беспокоенный", "bespokoyennyy" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 262L },
                column: "transcription",
                value: "tokobaku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 263L },
                columns: new[] { "text", "transcription" },
                values: new object[] { " anywhere: 任何地方 (rènhé dìfang)", "reh-neh-fuh di-fang" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 263L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "कहीं भी (kahin bhi)", "kuh-heen bhee" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 265L },
                column: "transcription",
                value: "be-tsu-ni");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 265L },
                column: "transcription",
                value: "alāg");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 267L },
                column: "transcription",
                value: "aya-ru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 267L },
                column: "transcription",
                value: "dao-dian");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 268L },
                column: "transcription",
                value: "sha-tsu-wai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 270L },
                column: "transcription",
                value: "so-sei");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 272L },
                column: "transcription",
                value: "xiǎn ràng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 273L },
                column: "transcription",
                value: "u-ke");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 276L },
                column: "transcription",
                value: "ah-pah-tehr");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 276L },
                column: "transcription",
                value: "a-ra-w-a-ru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 277L },
                column: "transcription",
                value: "wah-bih-ao");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 279L },
                column: "transcription",
                value: "ha-te-su-ru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 281L },
                column: "transcription",
                value: "yū-ka-ri-na-ru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 281L },
                column: "transcription",
                value: "ahn-ven-dar");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 282L },
                column: "transcription",
                value: "kan-dee");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 284L },
                column: "transcription",
                value: "mo-shi-no-mu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 285L },
                column: "transcription",
                value: "reki-mei suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 285L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "ernenben", "ern-nen" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 289L },
                column: "transcription",
                value: "ah-sehr-kee-ah-men-toh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 289L },
                column: "transcription",
                value: "fang-fa");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 508L },
                column: "transcription",
                value: "shuzuru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 508L },
                column: "transcription",
                value: "peɾte'neɾ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 508L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "बेला", "belā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 520L },
                column: "transcription",
                value: "ri-yaku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 522L },
                column: "transcription",
                value: "magatte-ta");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 522L },
                column: "transcription",
                value: "muDA");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 523L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "の", "no" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 525L },
                column: "transcription",
                value: "kaso ni kutte");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 525L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "अतिरिक्त", "a-tri-ta" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 535L },
                column: "transcription",
                value: "ma no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 535L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "entremez", "en-teh-mehs" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 536L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "の", "no" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 539L },
                column: "transcription",
                value: "pyān jiàn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 539L },
                column: "transcription",
                value: "pūrvāgrāh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 541L },
                column: "transcription",
                value: "li-ta-tsi-ón");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 542L },
                column: "transcription",
                value: "nyūtsaku suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 544L },
                column: "transcription",
                value: "zi-dong-che");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 545L },
                column: "transcription",
                value: "seiyūsho");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 547L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "billón", "biˈjon" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 548L },
                column: "transcription",
                value: "kon-teh-dor");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 549L },
                column: "transcription",
                value: "svyzyvat'");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 551L },
                column: "transcription",
                value: "seiyō-gaku-teki na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 557L },
                column: "transcription",
                value: "zhào-shì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 567L },
                column: "transcription",
                value: "yameru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 568L },
                column: "transcription",
                value: "ku-kai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 569L },
                column: "transcription",
                value: "ku-uchi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 569L },
                column: "transcription",
                value: "kuài-bái");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 570L },
                column: "transcription",
                value: "mōbu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 571L },
                column: "transcription",
                value: "bào tóu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 572L },
                column: "transcription",
                value: "bào zha");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 573L },
                column: "transcription",
                value: "shukkutsu suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 577L },
                column: "transcription",
                value: "shūfuku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 578L },
                column: "transcription",
                value: "mōmei no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 580L },
                column: "transcription",
                value: "zhǔdì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 581L },
                column: "transcription",
                value: "blob");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 589L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "subir", "soo-beer" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 591L },
                column: "transcription",
                value: "funā");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 594L },
                column: "transcription",
                value: "datan");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 595L },
                column: "transcription",
                value: "zhàdān");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 598L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "laurel", "lao-rel" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 598L },
                column: "transcription",
                value: "zhàiqián");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 600L },
                column: "transcription",
                value: "bōnassu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 602L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "registrar", "regaistrar" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 609L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "fronte", "fʁɔ̃te" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 609L },
                column: "transcription",
                value: "rinzetsu suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 617L },
                column: "transcription",
                value: "oyamaseru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 618L },
                column: "transcription",
                value: "boruto");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 620L },
                column: "transcription",
                value: "shita");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 622L },
                column: "transcription",
                value: "shibawarareta");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 624L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "узел", "oo-zyel" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 624L },
                column: "transcription",
                value: "nuhd");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 624L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "弓", "yumi" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 624L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "arco", "ar-ko" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 624L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "Bogen", "Bo:gen" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 626L },
                column: "transcription",
                value: "toh-sohn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 751L },
                column: "transcription",
                value: "ka-reh-puh-to");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 752L },
                column: "transcription",
                value: "basosha");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 754L },
                column: "transcription",
                value: "нести");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 754L },
                column: "transcription",
                value: "hatanbu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 754L },
                column: "transcription",
                value: "bǎodài");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 756L },
                column: "transcription",
                value: "vizrezać'");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 756L },
                column: "transcription",
                value: "koru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 759L },
                column: "transcription",
                value: "du1 tao3");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 760L },
                column: "transcription",
                value: "yǎn jú rén zhēng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 761L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "wirken", "vehr-ken" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 766L },
                column: "transcription",
                value: "katoreguru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 767L },
                column: "transcription",
                value: "Ulov");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 767L },
                column: "transcription",
                value: "Hoka ku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 768L },
                column: "transcription",
                value: "tsu-ke-ru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 769L },
                column: "transcription",
                value: "katorī");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 770L },
                column: "transcription",
                value: "botenasu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 771L },
                column: "transcription",
                value: "jiā-chú");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 773L },
                column: "transcription",
                value: "hikikozusu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 773L },
                column: "transcription",
                value: "fɛɐ̯ˈʊɐ̯çən");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 774L },
                column: "transcription",
                value: "fɔʁʃɪxt");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 774L },
                column: "transcription",
                value: "sāw kāṇī");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 775L },
                column: "transcription",
                value: "ɐstroˈʐnɨj");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 775L },
                column: "transcription",
                value: "fɔɐ̯tˈziːçɪç");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 777L },
                column: "transcription",
                value: "shi 'di-");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 779L },
                column: "transcription",
                value: "tēnnō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 779L },
                column: "transcription",
                value: "Deyke");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 780L },
                column: "transcription",
                value: "iau");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 783L },
                column: "transcription",
                value: "sy'ly");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 784L },
                column: "transcription",
                value: "mu: bi: ti:");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 786L },
                column: "transcription",
                value: "zhung-yáung");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 788L },
                column: "transcription",
                value: "sen'tar");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 789L },
                column: "transcription",
                value: "yah-roon-heirt");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 790L },
                column: "transcription",
                value: "shiki-den");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 791L },
                column: "transcription",
                value: "ɐˈdʲenːɨˈdʲenːɨj");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 791L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "確かな (kakaina)", "ka-ka-i-na" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 792L },
                column: "transcription",
                value: "tadashikani");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 793L },
                column: "transcription",
                value: "kak-shin");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 794L },
                column: "transcription",
                value: "zhěn-shū");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 796L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "鎖す", "kusuru" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 798L },
                column: "transcription",
                value: "zawaraseru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 798L },
                column: "transcription",
                value: "noem'brahr");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 798L },
                column: "transcription",
                value: "adrsyata karna");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 799L },
                column: "transcription",
                value: "for-tzi-tzen-de/r");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 801L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "चुनना", "chunn-naa" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 802L },
                column: "transcription",
                value: "ahn-shproov-fol");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 804L },
                column: "transcription",
                value: "kyanpion");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 805L },
                column: "transcription",
                value: "sen-sen-shatsu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 807L },
                column: "transcription",
                value: "fer-ahn-duhng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 807L },
                column: "transcription",
                value: "biàn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 809L },
                column: "transcription",
                value: "pin-dao");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 810L },
                column: "transcription",
                value: "huàn lún");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 810L },
                column: "transcription",
                value: "araajakatta");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 814L },
                column: "transcription",
                value: "kaɾaktekˈɾista");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 815L },
                column: "transcription",
                value: "karak te ri zar");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 815L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "beschreiben", "beschрайbn" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 815L },
                column: "transcription",
                value: "varnya karna");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 816L },
                column: "transcription",
                value: "akjyzsjõ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 817L },
                column: "transcription",
                value: "zarzhat'");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 817L },
                column: "transcription",
                value: "kokuhatsusu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 818L },
                column: "transcription",
                value: "jizent");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 818L },
                column: "transcription",
                value: "zī shàn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 819L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "charm", "shar" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 822L },
                column: "transcription",
                value: "huà");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 824L },
                column: "transcription",
                value: "peresekyohn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 824L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "दौड़", "daud" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 825L },
                column: "transcription",
                value: "ō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 825L },
                column: "transcription",
                value: "fer-folk-en");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 825L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "पर्ख", "parkh" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 827L },
                column: "transcription",
                value: "hanasu:");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 829L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "安く (yakuku)", "yakuku" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 830L },
                column: "transcription",
                value: "juru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 830L },
                column: "transcription",
                value: "Shvintl");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 831L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "tricer", "tree-say" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 831L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "ずるい", "zurui" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1001L },
                column: "transcription",
                value: "hosho");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 1002L },
                column: "transcription",
                value: "so-vye-ryat'sya");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 1002L },
                column: "transcription",
                value: "kɔ̃kuʁe");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1002L },
                column: "transcription",
                value: "kē-ū");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 1002L },
                column: "transcription",
                value: "ve-tī-fɛrn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1002L },
                column: "transcription",
                value: "jìng-zhèng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1004L },
                column: "transcription",
                value: "yūnei");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 1004L },
                column: "transcription",
                value: "kɔˈmɛnt");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1004L },
                column: "transcription",
                value: "jog");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 1005L },
                column: "transcription",
                value: "sasarevaniye");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 1005L },
                column: "transcription",
                value: "vet-foer-behmp");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1005L },
                column: "transcription",
                value: "jìng-zhèng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1006L },
                column: "transcription",
                value: "jìng zhēng de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1011L },
                column: "transcription",
                value: "hooru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 1011L },
                column: "transcription",
                value: "komplemenTAR");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1014L },
                column: "transcription",
                value: "quán wán");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1019L },
                column: "transcription",
                value: "jūanpyō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1021L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "合併", "gappei" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1253L },
                column: "transcription",
                value: "jōchūin");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1259L },
                column: "transcription",
                value: "hīhōka");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1262L },
                column: "transcription",
                value: "hīhan");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1262L },
                column: "transcription",
                value: "píngpíng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1263L },
                column: "transcription",
                value: "pin-ping");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1272L },
                column: "transcription",
                value: "misei-seij no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1272L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "अकथ्थ", "aktha" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1273L },
                column: "transcription",
                value: "jānokō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1273L },
                column: "transcription",
                value: "can-ku-ru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1283L },
                column: "transcription",
                value: "saiyō suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1289L },
                column: "transcription",
                value: "osusu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1290L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "好奇", "hào-qíng" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1291L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "好奇心", "koukishin" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 1291L },
                column: "transcription",
                value: "kyuˈɾjos");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1294L },
                column: "transcription",
                value: "dei gan de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1297L },
                column: "transcription",
                value: "pāṭhakar");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1300L },
                column: "transcription",
                value: "kogu-ru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1301L },
                column: "transcription",
                value: "magotta");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 1301L },
                column: "transcription",
                value: "kwrbo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 1309L },
                column: "transcription",
                value: "see-klee");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 1309L },
                column: "transcription",
                value: "sees-kloh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1310L },
                column: "transcription",
                value: "jūkan suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1311L },
                column: "transcription",
                value: "hini-na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1327L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "चुनना", "chun-ná" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 1334L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "dater", "day-tay" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 1334L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "citar", "see-tahr" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1338L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "死んだ (shinda)", "shi:nda" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1356L },
                column: "transcription",
                value: "kɛt-su-i");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1357L },
                column: "transcription",
                value: "i-shi kɛt-ti");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1363L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "下降", "xià jiàng" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1363L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "गिरावट", "gi-raa-vat" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1366L },
                column: "transcription",
                value: "gyōso");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 1370L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "сделка", "sidélka" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1370L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "行為", "kōi" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 1370L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "acto", "ahk-toh" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1377L },
                column: "transcription",
                value: "jī bǎi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1377L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "हारना", "hārnā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1378L },
                column: "transcription",
                value: "kekan");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1378L },
                column: "transcription",
                value: "qiàn'xìng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1383L },
                column: "transcription",
                value: "kikka");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1383L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "缺陷", "qiē xìng" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1383L },
                column: "transcription",
                value: "kami");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 1389L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "défi", "deˈfi" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 1400L },
                column: "transcription",
                value: "vostok");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 1403L },
                column: "transcription",
                value: "ent-e-gar");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1404L },
                column: "transcription",
                value: "ha-chi-ku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1413L },
                column: "transcription",
                value: "hinin suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1418L },
                column: "transcription",
                value: "shutsū suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1419L },
                column: "transcription",
                value: "bucha");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 1419L },
                column: "transcription",
                value: "ah-bahy-toong");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1421L },
                column: "transcription",
                value: "yī-yàn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1421L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "निर्भर", "ni-har" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 1429L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "dépression", "depʁɛˈsjɔ̃" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1432L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "निर्मुक्त करना", "nir-muuk-ta kar-na" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1435L },
                column: "transcription",
                value: "yōshitsu suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1442L },
                column: "transcription",
                value: "atashi-suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1466L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "निलंबन", "nilamban" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1469L },
                column: "transcription",
                value: "kɛt-su-i-su-ru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1484L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "निर्देशक", "nir-de-shak" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 1492L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "differentié", "dɪfɛʁɑ̃je" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1503L },
                column: "transcription",
                value: "tamesu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 1517L },
                column: "transcription",
                value: "niye-sto-tok");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1521L },
                column: "transcription",
                value: "shi-san");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1522L },
                column: "transcription",
                value: "shi-san-de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1524L },
                column: "transcription",
                value: "shi-swān");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1529L },
                column: "transcription",
                value: "jiě gū");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 1531L },
                column: "transcription",
                value: "rasskryvat'");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1533L },
                column: "transcription",
                value: "wagikashi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1534L },
                column: "transcription",
                value: "waritsuku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1535L },
                column: "transcription",
                value: "quǎn tuì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1536L },
                column: "transcription",
                value: "ron'ron");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1540L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "差別の", "sabetsu no" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1541L },
                column: "transcription",
                value: "o-ron-suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1547L },
                column: "transcription",
                value: "ken'gai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1549L },
                column: "transcription",
                value: "kaikō suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1549L },
                column: "transcription",
                value: "jiě gū");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1550L },
                column: "transcription",
                value: "jiě gū");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 1552L },
                column: "transcription",
                value: "vytestnyat'");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1556L },
                column: "transcription",
                value: "sōbutsu suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1558L },
                column: "transcription",
                value: "arasu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1559L },
                column: "transcription",
                value: "daǎ-liao");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1560L },
                column: "transcription",
                value: "po-huài");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1561L },
                column: "transcription",
                value: "tōkeru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1561L },
                column: "transcription",
                value: "róu jiě");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1564L },
                column: "transcription",
                value: "dokokute na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1565L },
                column: "transcription",
                value: "kuben");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1566L },
                column: "transcription",
                value: "dokokute na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1567L },
                column: "transcription",
                value: "ku-be-tsu-ru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1568L },
                column: "transcription",
                value: "wagameru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1577L },
                column: "transcription",
                value: "qiàn shuǐ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1581L },
                column: "transcription",
                value: "zhuān-yí");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1586L },
                column: "transcription",
                value: "li-hon");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1587L },
                column: "transcription",
                value: "li hôn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 1594L },
                column: "transcription",
                value: "dakirovan't");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1601L },
                column: "transcription",
                value: "zhìpì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1603L },
                column: "transcription",
                value: "zhì-píng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 1605L },
                column: "transcription",
                value: "pazherstvovanie");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1622L },
                columns: new[] { "text", "transcription" },
                values: new object[] { " downstairs", "dai xià diàn" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1625L },
                column: "transcription",
                value: "shinan");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1626L },
                column: "transcription",
                value: "xiàrè");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1629L },
                column: "transcription",
                value: "sōgō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1633L },
                column: "transcription",
                value: "xùjù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 1641L },
                column: "transcription",
                value: "odetyvat'");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1641L },
                column: "transcription",
                value: "keru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1642L },
                column: "transcription",
                value: "kachigatta");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1651L },
                column: "transcription",
                value: "di");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 1656L },
                column: "transcription",
                value: "baran");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1657L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "मदिरालय", "madiraalay" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 1681L },
                column: "transcription",
                value: "zaranivat'");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1681L },
                column: "transcription",
                value: "zhuan");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1685L },
                column: "transcription",
                value: "qing-song");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1712L },
                column: "transcription",
                value: "yào-xíng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1713L },
                column: "transcription",
                value: "yǒu xìng de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1714L },
                column: "transcription",
                value: "yào xíng xìng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1729L },
                column: "transcription",
                value: "kōreいの");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1730L },
                column: "transcription",
                value: "eru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1739L },
                column: "transcription",
                value: "yǔ suàn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1742L },
                column: "transcription",
                value: "ta-ke-ru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1745L },
                column: "transcription",
                value: "ha-kyū suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1746L },
                column: "transcription",
                value: "jing-ying");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1750L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "อีเมลする", "i-mee-ru suru" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1752L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "शर्मीली", "shar-mee-lee" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1755L },
                column: "transcription",
                value: "utaishi-kan");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1756L },
                column: "transcription",
                value: "yiān rù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1757L },
                column: "transcription",
                value: "ti-xian");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1759L },
                column: "transcription",
                value: "shutsū suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1760L },
                column: "transcription",
                value: "shutsuten");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1762L },
                column: "transcription",
                value: "pūtsu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1764L },
                column: "transcription",
                value: "bhāvamātnā");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1765L },
                columns: new[] { "text", "transcription" },
                values: new object[] { " emotionally 情绪上 (qíngxù shang)", "tɕʰiŋ.ɕuː ʂɑŋ" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1765L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "भावनात्मक रूप से (bhāvamātrika rūpa se)", "bhɑːʋəmɑːtrikɑ rūp se" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1766L },
                column: "transcription",
                value: "qiān gāo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1767L },
                column: "transcription",
                value: "qiān-zhòng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1777L },
                column: "transcription",
                value: "yǐn huó");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1778L },
                column: "transcription",
                value: "seite suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1779L },
                column: "transcription",
                value: "hōsansuru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1781L },
                column: "transcription",
                value: "auu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1782L },
                column: "transcription",
                value: "ha-ma-su");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1785L },
                column: "transcription",
                value: "zhú jìn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1790L },
                column: "transcription",
                value: "su-i-shi-ru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1791L },
                column: "transcription",
                value: "su-sen-sho");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1794L },
                column: "transcription",
                value: "nér-liàng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1797L },
                column: "transcription",
                value: "yán-cù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1798L },
                column: "transcription",
                value: "konyō-chū no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1799L },
                column: "transcription",
                value: "konyō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 1804L },
                column: "transcription",
                value: "a-nong-mih-lehr");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1804L },
                column: "transcription",
                value: "ti-gāo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1810L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "これ", "kore" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 1810L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "le", "leh" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 1810L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "ihm", "ihm" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1810L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "他", "tā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1810L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "उसे", "use" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1811L },
                column: "transcription",
                value: "to-i-ke-ru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1812L },
                column: "transcription",
                value: "to:ikakeshi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1816L },
                column: "transcription",
                value: "kěng què");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1822L },
                column: "transcription",
                value: "reh-qing");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1824L },
                column: "transcription",
                value: "reh-qíng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1837L },
                column: "transcription",
                value: "dōyō na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1838L },
                column: "transcription",
                value: "dōyō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1839L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "बरा करना", "barā karnā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1840L },
                column: "transcription",
                value: "dōhō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1841L },
                column: "transcription",
                value: "dōyō ni");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 1846L },
                column: "transcription",
                value: "ek?v?l?nt");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1846L },
                column: "transcription",
                value: "s?t?i");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 1872L },
                column: "transcription",
                value: "naosrui");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 1872L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "siquiera", "siˈkjeɾa" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 1872L },
                column: "transcription",
                value: "gly:h");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 1872L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "बरा", "barā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 1877L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "jamais", "zhamé" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 1877L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "nunca", "nuŋka" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 1917L },
                column: "text",
                value: " exclusively 独家");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2002L },
                column: "transcription",
                value: "sai-go shite ru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2003L },
                column: "transcription",
                value: "nyedavshiyis'");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2003L },
                column: "transcription",
                value: "shi-ppatsu-shita");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2003L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "gescheiterter", "ge-shay-ter" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2004L },
                column: "transcription",
                value: "nʲɪˈdɑt͡ɕə");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2004L },
                column: "transcription",
                value: "shi-bō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2013L },
                column: "transcription",
                value: "khaaSei shoHarat");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2016L },
                column: "transcription",
                value: "jiā tǐng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2027L },
                column: "transcription",
                value: "arau");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2027L },
                column: "transcription",
                value: "vehr-shteh-ten");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2029L },
                column: "transcription",
                value: "zʲemlʲɪdʲɪˈlʲe");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2032L },
                column: "transcription",
                value: "hōkō no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2036L },
                column: "transcription",
                value: "tai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2038L },
                column: "transcription",
                value: "smertniy");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2038L },
                column: "transcription",
                value: "míngzhèng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2040L },
                column: "transcription",
                value: "chichi:");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2040L },
                column: "transcription",
                value: "fuqin");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2041L },
                column: "transcription",
                value: "atemachi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2043L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "favoriser", "faborisēru" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2045L },
                column: "transcription",
                value: "pasandī");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2046L },
                column: "transcription",
                value: "pasandī");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2048L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "haben", "hah-ben" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2048L },
                column: "transcription",
                value: "hā pà");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2049L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "करनामा", "karanāmā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2052L },
                column: "transcription",
                value: "me-wa-ta-se-ru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2054L },
                column: "transcription",
                value: "liànbāng de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2060L },
                column: "transcription",
                value: "gān jué");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2063L },
                column: "transcription",
                value: "tovarishchinskiy");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2064L },
                column: "transcription",
                value: "vai-lich");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2065L },
                column: "transcription",
                value: "nǚrén");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2066L },
                column: "transcription",
                value: "joseishiki na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 2066L },
                column: "transcription",
                value: "feɪˈmɪnɪstɑː");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 2067L },
                column: "transcription",
                value: "feh-mee-nah-stah");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2067L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "Femininistin", "Feh-mee-neen-shtin" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2068L },
                column: "transcription",
                value: "fensen");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2069L },
                column: "transcription",
                value: "jie-ri");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2075L },
                column: "transcription",
                value: "fɪkushon");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2075L },
                column: "transcription",
                value: "ksiǎo shū");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2075L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "काल्पनिक", "kaanpnik" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2076L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "野", "no:" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 2077L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "fiero", "fee-roh" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2081L },
                column: "transcription",
                value: "senbi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2081L },
                column: "transcription",
                value: "kambf");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2082L },
                column: "transcription",
                value: "kempen");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2086L },
                column: "transcription",
                value: "dah-ee");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2087L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "загружать", "zagruzhat'" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 2087L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "télécharger", "telecharzhe" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2087L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "アップロードする", "appurōdo suru" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 2087L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "limar", "lee-mahr" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2090L },
                column: "transcription",
                value: "satō suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2092L },
                column: "transcription",
                value: "jǐ shù qì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2096L },
                column: "transcription",
                value: "zhū yú");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2097L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "Finanzierung", "fee-nahnts-e-roong" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2097L },
                column: "transcription",
                value: "jin-roeng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2097L },
                column: "transcription",
                value: "vit");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 2100L },
                column: "transcription",
                value: "en-kon-tar");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2104L },
                column: "transcription",
                value: "shoshatsu suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2104L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "verdondern", "fer-dohr-en" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2107L },
                column: "transcription",
                value: "oueru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2107L },
                column: "transcription",
                value: "bay-en");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2109L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "बर्बाद करना", "barbād karnā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2110L },
                column: "transcription",
                value: "ognevstrel'noye oruzhiye");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2258L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "топливо", "toplivo" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2258L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "燃料する", "nenryō suru" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2258L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "燃料", "ránliào" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 2261L },
                column: "transcription",
                value: "a tɑ̃ ʁɛ̃ ʁə");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 2261L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "completo", "kom-pleh-toh" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2261L },
                column: "transcription",
                value: "kwánzhí");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2262L },
                column: "transcription",
                value: "furutoaimu de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2262L },
                column: "transcription",
                value: "chwan-zhi de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2271L },
                column: "transcription",
                value: "kijiteki na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2272L },
                column: "transcription",
                value: "mooĹ rÅp se");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2275L },
                column: "transcription",
                value: "sōgiyō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 2275L },
                column: "transcription",
                value: "fyuneral");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2275L },
                column: "transcription",
                value: "zhànglǐ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2277L },
                column: "transcription",
                value: "hige");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 2278L },
                column: "transcription",
                value: "fyoo-ree-uh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2280L },
                column: "transcription",
                value: "vah-yuh-rah");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2282L },
                column: "transcription",
                value: "fēicǐ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2284L },
                column: "transcription",
                value: "tsook-foot");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2284L },
                column: "transcription",
                value: "mei-lai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2289L },
                column: "transcription",
                value: "g Yanburu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2291L },
                column: "transcription",
                value: "ǒu xì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2292L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "Band", "bahn" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2293L },
                column: "transcription",
                value: "kigami");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2298L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "集まる", "atsu-ma-ru" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2298L },
                column: "transcription",
                value: "jíqí");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2299L },
                column: "transcription",
                value: "shūmari");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2303L },
                column: "transcription",
                value: "ni-kagi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2304L },
                column: "transcription",
                value: "xing-bi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 2305L },
                column: "transcription",
                value: "ʒɑ̃n");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2305L },
                column: "transcription",
                value: "yūdentsu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2309L },
                column: "transcription",
                value: "shi-dai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2312L },
                column: "transcription",
                value: "yún yuán de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 2314L },
                column: "transcription",
                value: "xenotsidio");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2318L },
                column: "transcription",
                value: "vastiik");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2322L },
                column: "transcription",
                value: "děi dào");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2328L },
                column: "transcription",
                value: "onnanōko");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2335L },
                column: "transcription",
                value: "ippē");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2338L },
                column: "transcription",
                value: "chikūgi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2348L },
                column: "transcription",
                value: "kinkaichii");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2351L },
                column: "transcription",
                value: "hǎo chū");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2353L },
                column: "transcription",
                value: "wake");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2354L },
                column: "transcription",
                value: "yūshisa");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2354L },
                column: "transcription",
                value: "Shan-ran");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2355L },
                column: "transcription",
                value: "shēngpǐn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2360L },
                column: "transcription",
                value: "shishi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2363L },
                column: "transcription",
                value: "seikei");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2372L },
                column: "transcription",
                value: "sofu-bo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2374L },
                column: "transcription",
                value: "zhōu rǔ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2398L },
                column: "transcription",
                value: "nigu(r)u");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2399L },
                column: "transcription",
                value: "shi-pin");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2400L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "むさ苦しい", "musakushii" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2409L },
                column: "transcription",
                value: "yóu jí duì mián");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2409L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "गuerilla", "guh-AIR-ih-lah" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2417L },
                column: "transcription",
                value: "zainakukan");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2418L },
                column: "transcription",
                value: "tsu-wa-ku-kan-no-aru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2419L },
                column: "transcription",
                value: "gì-tā");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2422L },
                column: "transcription",
                value: "jiā rě");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2426L },
                column: "transcription",
                value: "keu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2429L },
                column: "transcription",
                value: "ya ban");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 2501L },
                column: "transcription",
                value: "su:");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2502L },
                column: "transcription",
                value: "ye:'yo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2507L },
                column: "transcription",
                value: "ye:yo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2509L },
                column: "transcription",
                value: "tame-rau");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2512L },
                column: "transcription",
                value: "yin-cáng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2513L },
                column: "transcription",
                value: "yin-kang");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2514L },
                column: "transcription",
                value: "dèng jí zhì dù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 2515L },
                column: "transcription",
                value: "o: 'o'");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2518L },
                column: "transcription",
                value: "chūmon o ātomeru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2518L },
                column: "transcription",
                value: "prisht");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2519L },
                column: "transcription",
                value: "hai-ra-to");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2519L },
                column: "transcription",
                value: "zohr");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2522L },
                column: "transcription",
                value: "kōdō dora");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2523L },
                column: "transcription",
                value: "o-mo-shi-ro-i");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2524L },
                column: "transcription",
                value: "kyū");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2526L },
                column: "transcription",
                value: "kare jiko");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2527L },
                column: "transcription",
                value: "tí-shì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2529L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "股", "maki" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2530L },
                column: "transcription",
                value: "saǐyo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2530L },
                column: "transcription",
                value: "āi-yōng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2533L },
                column: "transcription",
                value: "zay:n");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2534L },
                column: "transcription",
                value: "ˈrekishi gakusha");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2535L },
                column: "transcription",
                value: "li-shi-de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2536L },
                column: "transcription",
                value: "li-shih-deh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2537L },
                column: "transcription",
                value: "li-shi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2540L },
                column: "transcription",
                value: "shúmi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2542L },
                column: "transcription",
                value: "hojō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2545L },
                column: "transcription",
                value: "híe-rì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2546L },
                column: "transcription",
                value: "ku'udō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2548L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "自前の", "ji-no" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2549L },
                column: "transcription",
                value: "tsook");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2555L },
                column: "text",
                value: "正直");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2556L },
                column: "transcription",
                value: "róng-yù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2557L },
                column: "transcription",
                value: "ménaeru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2557L },
                column: "transcription",
                value: "eh-run");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2559L },
                column: "transcription",
                value: "hi-tsu-ka-ke-ru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2561L },
                column: "transcription",
                value: "nadeятся'");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2563L },
                column: "transcription",
                value: "oshashi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2566L },
                column: "transcription",
                value: "hi-do-i");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2566L },
                column: "transcription",
                value: "ke-pa");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 2570L },
                column: "transcription",
                value: "an-tee-fí-ron");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2570L },
                column: "transcription",
                value: "zhǔ-zhǎng-rén");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2572L },
                column: "transcription",
                value: "jintsu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2574L },
                column: "transcription",
                value: "teki");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2576L },
                column: "transcription",
                value: "jiu-diān");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2577L },
                column: "transcription",
                value: "shi-o");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2579L },
                column: "transcription",
                value: "fukameru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2581L },
                column: "transcription",
                value: "z힐'ye");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2589L },
                column: "transcription",
                value: "ken-kyo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2590L },
                column: "transcription",
                value: "jyuumorasu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2593L },
                column: "transcription",
                value: "ukue");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2596L },
                column: "transcription",
                value: "kuru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2596L },
                column: "transcription",
                value: "shou lie");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2600L },
                column: "transcription",
                value: "gān-jǐn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2601L },
                column: "transcription",
                value: "kizutsita");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2602L },
                column: "transcription",
                value: "tóngrén");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2602L },
                column: "transcription",
                value: "dārd");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2603L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "चलाना", "chāla-na" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2604L },
                column: "transcription",
                value: "o-u");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2605L },
                column: "transcription",
                value: "xiāng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 2606L },
                column: "transcription",
                value: "hipə˖ɣ˖s");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2607L },
                column: "transcription",
                value: "ma͠");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2609L },
                column: "transcription",
                value: "aɪs ˈkɹiːm");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2611L },
                column: "transcription",
                value: "ai-di-");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2612L },
                column: "transcription",
                value: "si'suh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2615L },
                column: "transcription",
                value: "kwán wán xiāng děng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2616L },
                column: "transcription",
                value: "shi-ben");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2616L },
                column: "transcription",
                value: "shan-fen-ren-shi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2617L },
                column: "transcription",
                value: "to-ka-te-su-ru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2619L },
                column: "transcription",
                value: "yìshí tàixìng de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2620L },
                column: "transcription",
                value: "yì shǐ xíng tài");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 2622L },
                column: "transcription",
                value: "see:");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2622L },
                column: "transcription",
                value: "moshi:");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2624L },
                column: "transcription",
                value: "mu-shi-ru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2624L },
                column: "transcription",
                value: "hūlü");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2624L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "उखाड़ना", "ukhāṛnā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2628L },
                column: "transcription",
                value: "sakugaku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2630L },
                column: "transcription",
                value: "i-rasuto");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2632L },
                column: "transcription",
                value: "iːmajjiː");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 2633L },
                column: "transcription",
                value: "ee-ma-nehr");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2633L },
                column: "transcription",
                value: "souzoujyou no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2633L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "gesinnungsvoll", "ge-zeen-oongs-fool" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 2634L },
                column: "transcription",
                value: "imaɣiˈnosjon");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2634L },
                column: "transcription",
                value: "xiǎng’xiàng lì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 2635L },
                column: "transcription",
                value: "imaˈxar");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2636L },
                column: "transcription",
                value: "li-ji");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2637L },
                column: "transcription",
                value: "li-ji");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2639L },
                column: "transcription",
                value: "i-min-ka");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2641L },
                column: "transcription",
                value: "sas-hi-sa-ko-tta");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2641L },
                column: "transcription",
                value: "pò zài méi liè");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2642L },
                column: "transcription",
                value: "minki no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2642L },
                column: "transcription",
                value: "miú-yù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2646L },
                column: "transcription",
                value: "shi shi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2647L },
                column: "transcription",
                value: "ji-shō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2647L },
                column: "transcription",
                value: "shi-shi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2649L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "सूचक", "soochak" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2650L },
                column: "transcription",
                value: "nyūnyū");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2651L },
                column: "transcription",
                value: "nyūnyū suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2652L },
                column: "transcription",
                value: "zhong-yao-xing");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2654L },
                column: "transcription",
                value: "kyōsu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2656L },
                column: "transcription",
                value: "kansin-sa-seru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2656L },
                column: "transcription",
                value: "dǎ dōng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2657L },
                column: "transcription",
                value: "yin xiang shen ke");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2658L },
                column: "transcription",
                value: "yin xiàng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2659L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "印象的な (inshōteki na)", "in-shōh-teh-ki na" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2660L },
                column: "transcription",
                value: "jian-jin");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2661L },
                column: "transcription",
                value: "jiān jīn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2667L },
                column: "transcription",
                value: "bu-zú");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2671L },
                column: "transcription",
                value: "ɡəˈt̪ʰɑː");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2672L },
                column: "transcription",
                value: "shi-jian");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2674L },
                column: "transcription",
                value: "bao-kuo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2675L },
                column: "transcription",
                value: "fu-ku-mu-re-ta");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2676L },
                column: "transcription",
                value: "gu-mu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2677L },
                column: "transcription",
                value: "hōsei");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2678L },
                column: "transcription",
                value: "shōu-rù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2682L },
                column: "transcription",
                value: "foo-yah-soo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2683L },
                column: "transcription",
                value: "ma-su ma-su");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2683L },
                column: "transcription",
                value: "ri ri");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2685L },
                column: "transcription",
                value: "shinji-rai-nai-hodo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2685L },
                column: "transcription",
                value: "nan-yi-zhi-xin");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2686L },
                column: "transcription",
                value: "umaru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2687L },
                column: "transcription",
                value: "tadashika ni");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2688L },
                column: "transcription",
                value: "du-li");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2689L },
                column: "transcription",
                value: "doku-ryo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2689L },
                column: "transcription",
                value: "dú lǐ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2690L },
                column: "transcription",
                value: "shōsai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2690L },
                column: "transcription",
                value: "suǒ-zhi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2691L },
                column: "transcription",
                value: "shi-su");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2692L },
                column: "transcription",
                value: "ji-xiang");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2693L },
                column: "transcription",
                value: "zhi-bi-ao");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2694L },
                column: "transcription",
                value: "kishi-so");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2696L },
                column: "transcription",
                value: "kan-che-teki-na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2696L },
                column: "transcription",
                value: "apraksh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 2697L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "distinctif", "dis-tin-ktiv" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2697L },
                column: "transcription",
                value: "ko-be-tsu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 2697L },
                column: "transcription",
                value: "in-di-vi-dsh-u-al");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2697L },
                column: "transcription",
                value: "ge-ren");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2698L },
                column: "transcription",
                value: "ge-ren");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2699L },
                column: "transcription",
                value: "shī nèi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2700L },
                column: "transcription",
                value: "shi nei");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2701L },
                column: "transcription",
                value: "yūhatsusu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2701L },
                column: "transcription",
                value: "yòu-dǎo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2702L },
                column: "transcription",
                value: "ama-njeru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2704L },
                column: "transcription",
                value: "gōng-yè");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2704L },
                column: "transcription",
                value: "oo-dug");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2705L },
                column: "transcription",
                value: "fu-hei-dou");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2705L },
                column: "transcription",
                value: "Oong-glekh-hite");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2707L },
                column: "transcription",
                value: "hizen-teki ni");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 2707L },
                column: "transcription",
                value: "inevitáblemente");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2708L },
                column: "transcription",
                value: "aku-mei takai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2708L },
                column: "transcription",
                value: "zhòu míng zhāo zhù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2709L },
                column: "transcription",
                value: "mladentss");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2709L },
                column: "transcription",
                value: "yin-er");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2712L },
                column: "transcription",
                value: "to-so-ku-suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2714L },
                column: "transcription",
                value: "tsu-yo-o-bu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2714L },
                column: "transcription",
                value: "qiang-jia");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2715L },
                column: "transcription",
                value: "ying-xiang");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2716L },
                column: "transcription",
                value: "ying-xiang");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2718L },
                column: "transcription",
                value: "informatschoon");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2718L },
                column: "transcription",
                value: "xìn xī");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2719L },
                column: "transcription",
                value: "shi-ra-se-ru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2720L },
                column: "transcription",
                value: "ka-ji-aru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2721L },
                column: "transcription",
                value: "Informatsiyon");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 2722L },
                column: "transcription",
                value: "ˌɪnfrəˈstrʌktʃər");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2723L },
                column: "transcription",
                value: "zaǐryō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2723L },
                column: "transcription",
                value: "tsoot");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2724L },
                column: "transcription",
                value: "jū-mín");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2725L },
                column: "transcription",
                value: "kon-gu no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2726L },
                column: "transcription",
                value: "yí chéng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2727L },
                column: "transcription",
                value: "yosei suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2727L },
                column: "transcription",
                value: "yìbì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2728L },
                column: "transcription",
                value: "zh-uh-loh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2729L },
                column: "transcription",
                value: "to-sho");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2729L },
                column: "transcription",
                value: "zh-u-yau");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 2730L },
                column: "transcription",
                value: "in-i-ar");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2730L },
                column: "transcription",
                value: "ka-i-shi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2732L },
                column: "transcription",
                value: "chūsai suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2732L },
                column: "transcription",
                value: "zhāoshè");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2733L },
                column: "transcription",
                value: "zhā shì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2734L },
                column: "transcription",
                value: "chot pahūnā");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2735L },
                column: "transcription",
                value: "shòu-ráng de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2740L },
                column: "transcription",
                value: "ˈūchi no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2741L },
                column: "transcription",
                value: "mujuzu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2742L },
                column: "transcription",
                value: "xīn chuàng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2744L },
                column: "transcription",
                value: "i-n-put-su");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2745L },
                column: "transcription",
                value: "u-ka-te-i");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2745L },
                column: "transcription",
                value: "ahn-froh-eh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2745L },
                column: "transcription",
                value: "xun wen");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2750L },
                column: "transcription",
                value: "li-mien");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 2753L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "informador", "infor'ma:dor" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2754L },
                column: "transcription",
                value: "dō-ka-ryoku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2763L },
                column: "transcription",
                value: "an-li");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2769L },
                column: "transcription",
                value: "ukrazhdeniye");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 2769L },
                column: "transcription",
                value: "ɛʀtisfjœsjɔ̃");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2769L },
                column: "transcription",
                value: "kīkan");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2769L },
                column: "transcription",
                value: "in-sti-tyoo-shuhn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2770L },
                column: "transcription",
                value: "zhì dòu de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2772L },
                column: "transcription",
                value: "ni-resh-ton");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2774L },
                column: "transcription",
                value: "gakkì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2781L },
                column: "transcription",
                value: "pas-poo-pleh-nee-ye");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2781L },
                column: "transcription",
                value: "shou-nyu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2782L },
                column: "transcription",
                value: "bu-ke-fen-gei-de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2784L },
                column: "transcription",
                value: "in-teh-ɡri-ráv-nyy");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2788L },
                column: "transcription",
                value: "chishinin");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2790L },
                column: "transcription",
                value: "ka-shi-i");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2790L },
                column: "transcription",
                value: "in-teh-lee-geht");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2791L },
                column: "transcription",
                value: "i.to suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2793L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "intens", "in-tens" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2793L },
                column: "transcription",
                value: "qiángliào");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2794L },
                column: "transcription",
                value: "usilit'vat'");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2794L },
                column: "transcription",
                value: "gēka suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2795L },
                column: "transcription",
                value: "tsuyosa");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2796L },
                column: "transcription",
                value: "mì-ch密");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2799L },
                column: "transcription",
                value: "sou-go-kou-sai-suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2799L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "wirken", "veer-ken" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 2801L },
                column: "transcription",
                value: "jì jiǎo shì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 2801L },
                column: "transcription",
                value: "san-va-da-a-tak");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2804L },
                column: "transcription",
                value: "zainteresting");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2805L },
                column: "transcription",
                value: "interestnyy");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2807L },
                column: "transcription",
                value: "kan-wa-suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2808L },
                column: "transcription",
                value: "kan-wa");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 2809L },
                column: "transcription",
                value: "pwah-vee-zwar");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2810L },
                column: "transcription",
                value: "uchinō shita");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2810L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "inner", "ˈɪnər" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 2811L },
                column: "transcription",
                value: "IN-en-roy");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 3001L },
                column: "transcription",
                value: "keet-air");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3008L },
                column: "transcription",
                value: "yi-chang");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3009L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "合法（ほうかつ）", "hōkatsu" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3009L },
                column: "transcription",
                value: "héfá");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3010L },
                column: "transcription",
                value: "ledenda");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3012L },
                column: "transcription",
                value: "ripsō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 3012L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "विधायी प्रक्रिया", "vidhaayee prashasya" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3015L },
                column: "transcription",
                value: "seidō na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3015L },
                column: "transcription",
                value: "he-fa");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3017L },
                column: "transcription",
                value: "nin-g-meng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3023L },
                column: "transcription",
                value: "shiraku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3030L },
                column: "transcription",
                value: "tezumi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3046L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "вечный", "vyech-nyy" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3061L },
                column: "transcription",
                value: "zhi1");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3067L },
                column: "transcription",
                value: "piān-liè");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3068L },
                column: "transcription",
                value: "namabi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3068L },
                column: "transcription",
                value: "rén-zōng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3074L },
                column: "transcription",
                value: "kuchi:");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3074L },
                column: "transcription",
                value: "zhou chēn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3075L },
                column: "transcription",
                value: "zhyvkiy");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3075L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "液体", "eikiki" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3076L },
                column: "transcription",
                value: "zheidkost'");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3076L },
                column: "transcription",
                value: "えきたい");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3076L },
                column: "transcription",
                value: "yèti");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3091L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "он/она", "on/ona" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 3091L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "lui/elle", "lwee/el" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3091L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "彼/彼女", "kare/kanojo" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3091L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "él/ella", "el/eya" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 3091L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "er", "air" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3091L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "他", "tā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 3091L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "वह", "vah" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3135L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "él", "el" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 3135L },
                column: "transcription",
                value: "ain t'ail");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 3167L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "courriel", "kuriel" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3170L },
                column: "transcription",
                value: "honpō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3170L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "continental", "kon-tin-en-tal" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3177L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "título", "tee-too-loh" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 3177L },
                column: "transcription",
                value: "hauftfakh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 3179L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "fabriqué", "fabʁike" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3179L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "fábrica", "fah-'bree-kah" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3200L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "они", "oni" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 3200L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "ils", "ilz" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3200L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "彼ら", "karera" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3200L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "ellos", "e'ʎos:" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 3200L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "sie", "zi:" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3200L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "他们", "tāmen" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 3200L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "वे", "ve" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3205L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "marzo", "maerthoh" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3208L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "марга́льный", "maˈrɡalnɨj" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 3209L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "marinen", "maˈʁiːnən" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 3224L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "बलिदान", "balidān" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3232L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "mezclar", "mez-klar" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 3233L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "anziehend", "ˈantsˌtsɪçt" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3233L },
                column: "transcription",
                value: "cǎo zhì de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 3246L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "möchte", "mœxtʃtə" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3253L },
                column: "transcription",
                value: "yoou yihng-yih");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3254L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "смысл", "smysl" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 3254L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "sens", "sã:" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3254L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "意味", "imi:" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 3254L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "Sinn", "zeen" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3254L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "意义", "yìyì" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 3254L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "मतलब", "matlab" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3255L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "tanto", "ˈtanto" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 3255L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "Solange", "zoh-lahn-geh" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3256L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "mientras", "mjɛnˈtaw" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3256L },
                column: "transcription",
                value: "yǐng'érshí");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3258L },
                column: "transcription",
                value: "ta.su.ru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3259L },
                column: "transcription",
                value: "cè lĭ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3261L },
                column: "transcription",
                value: "ji-guo shī");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3262L },
                column: "transcription",
                value: "ki-ka-te-ki-na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3262L },
                column: "transcription",
                value: "jī gōng de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 3262L },
                column: "transcription",
                value: "yantraik");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3265L },
                column: "transcription",
                value: "mee-dee-ah");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3265L },
                column: "transcription",
                value: "mei-ti-ah");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 3266L },
                column: "transcription",
                value: "meh-di-t͡sɪʃ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3266L },
                column: "transcription",
                value: "yī xué dì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3268L },
                column: "transcription",
                value: "ku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3269L },
                column: "transcription",
                value: "zhōng shí jì de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3271L },
                column: "transcription",
                value: "jūng děng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 3272L },
                column: "transcription",
                value: "mwãn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3272L },
                column: "transcription",
                value: "tsūchi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3272L },
                column: "transcription",
                value: "mei-ji");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 3274L },
                column: "transcription",
                value: "ʁe.jɔ̃.jɔ̃");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 3274L },
                column: "transcription",
                value: "bhaithak");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3277L },
                column: "transcription",
                value: "chéngyǔn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3278L },
                column: "transcription",
                value: "kaigiin");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3278L },
                column: "transcription",
                value: "membresía");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 3278L },
                column: "transcription",
                value: "Mit-gli-shaft");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3280L },
                column: "transcription",
                value: "kaikuroku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3281L },
                column: "transcription",
                value: "o moidebukai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3281L },
                column: "transcription",
                value: "in-o-lee-dah-ble");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 3284L },
                column: "transcription",
                value: "g'ai-shtig");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3284L },
                column: "transcription",
                value: "jīng shén de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3285L },
                column: "transcription",
                value: "gēn-ki");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 3285L },
                column: "transcription",
                value: "er-vuhnng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3285L },
                column: "transcription",
                value: "tí-jù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3286L },
                column: "transcription",
                value: "gen-ki suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3286L },
                column: "transcription",
                value: "tí-jiù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3287L },
                column: "transcription",
                value: "men-ta-");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3288L },
                column: "transcription",
                value: "kǎo-dān");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 3288L },
                column: "transcription",
                value: "me.nu:");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3290L },
                column: "transcription",
                value: "mee-sehr-koh-dee-ah");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3290L },
                column: "transcription",
                value: "lee-an-min");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 3290L },
                column: "transcription",
                value: "d-yaa");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3291L },
                column: "transcription",
                value: "jǐn jiàn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3292L },
                column: "transcription",
                value: "sim-plen-te");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3292L },
                column: "transcription",
                value: "jǐn jiǎn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3296L },
                column: "transcription",
                value: "huàn lún");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3299L },
                column: "transcription",
                value: "on-yū");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3299L },
                column: "transcription",
                value: "yǐn yù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3301L },
                column: "transcription",
                value: "ho-dō-ron");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3301L },
                column: "transcription",
                value: "fāngfǎ lùn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3305L },
                column: "transcription",
                value: "polunochn' ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3305L },
                column: "transcription",
                value: "ma-na-ka");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3307L },
                column: "transcription",
                value: "mozu yumei");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 3307L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "शक", "śak" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3308L },
                column: "transcription",
                value: "i-ju-ju");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 3309L },
                column: "transcription",
                value: "z'anft");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3309L },
                column: "transcription",
                value: "wēn hé");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 3311L },
                column: "transcription",
                value: "mi.lɑ̃");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3311L },
                column: "transcription",
                value: "kaku-geki na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3311L },
                column: "transcription",
                value: "belɪˈxɾante");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3311L },
                column: "transcription",
                value: "jī jìn de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 3312L },
                column: "transcription",
                value: "miˈlɑ̃");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3312L },
                column: "transcription",
                value: "kazeikiha");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3312L },
                column: "transcription",
                value: "jī jìn fèn zi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 3312L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "अग्रगामी", "ag-rah-gah-mee" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 3313L },
                column: "transcription",
                value: "mi.lɛʁ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3313L },
                column: "transcription",
                value: "jun-shi-de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3314L },
                column: "transcription",
                value: "jun-dui");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3317L },
                column: "transcription",
                value: "melítsa");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3359L },
                column: "transcription",
                value: "wēn hé");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 3501L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "creneau", "kʁəˈnø" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3501L },
                column: "transcription",
                value: "ˈnɪt͡ɕi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3501L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "hueco", "weh-koh" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3522L },
                column: "transcription",
                value: "shougotsu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3523L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "そして", "soshite" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3535L },
                column: "transcription",
                value: "chūmei-na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3545L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "известный", "izvéstnyy" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3545L },
                column: "transcription",
                value: "akumei takai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3546L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "novelesco", "no-veh-les-ko" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3547L },
                column: "transcription",
                value: "ksiǎo shuō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 3559L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "poussoir", "pu.sœʁ" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3562L },
                column: "transcription",
                value: "ying-yang");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3567L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "направлять", "napravlyat'" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3567L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "apuntar", "apoon-tahr" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3572L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "頼む", "tay-mu" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3576L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "ひ fixate (fikusuru)", "fiku suru" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3580L },
                column: "transcription",
                value: "meibaku na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3581L },
                column: "transcription",
                value: "xiǎn ràng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3582L },
                column: "transcription",
                value: "k'ai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3583L },
                column: "transcription",
                value: "shi-o-ri");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3584L },
                column: "transcription",
                value: "eez-noh-dah");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3584L },
                column: "transcription",
                value: "tshi-tshi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3597L },
                column: "transcription",
                value: "o-ko-ru-se-ru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3599L },
                column: "transcription",
                value: "fukaiana");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 3599L },
                column: "transcription",
                value: "aa-gha-taka");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3601L },
                column: "transcription",
                value: "mochiideru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3606L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "公式", "koh-shi-ki" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3611L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "apto", "ap-toh" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3618L },
                column: "transcription",
                value: "cóngqí");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3619L },
                column: "transcription",
                value: "ceng jing");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3620L },
                column: "transcription",
                value: "ičči");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3622L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "я", "ya" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 3622L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "je", "zhuh" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3622L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "私", "watashi" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 3622L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "ich", "ikh" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3622L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "我", "wǒ" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 3622L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "मैं", "ma͠i(n)" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3624L },
                column: "transcription",
                value: "tane-gi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3634L },
                column: "transcription",
                value: "ge wu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3635L },
                column: "transcription",
                value: "sōte suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3636L },
                column: "transcription",
                value: "shujō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3642L },
                column: "transcription",
                value: "hǎn-tai suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3649L },
                column: "transcription",
                value: "eru-bu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3649L },
                column: "transcription",
                value: "xuǎnzuò");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3653L },
                column: "transcription",
                value: "xùan-xiàn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3655L },
                column: "transcription",
                value: "kū tō no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3759L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "пришвартовать", "prishvartovat'" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 3759L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "amarrer", "ah-mah-ray" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3759L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "停泊する", "teiboku suru" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3759L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "entrenar", "en-treh-nahr" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3762L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "议会", "yì huì" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3770L },
                column: "transcription",
                value: "to-ku-no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3777L },
                column: "transcription",
                value: "proyti:");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 3777L },
                column: "transcription",
                value: "pase:");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3777L },
                column: "transcription",
                value: "wataru:");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3778L },
                column: "transcription",
                value: "dōro");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3783L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "受動的な (jūdōteki na)", "jū-dō-teki na" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3797L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "терпеливый", "terpelivyy" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 3797L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "Geduldiger", "geh-dools-tih-ger" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3797L },
                column: "transcription",
                value: "bing-ren");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 3797L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "धैर्यवान", "dhair-ya-waan" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3798L },
                column: "transcription",
                value: "xún lāo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3799L },
                column: "transcription",
                value: "xún lāo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3801L },
                column: "transcription",
                value: "patōn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3804L },
                column: "transcription",
                value: "jinkīn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3806L },
                column: "transcription",
                value: "shi-nai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3813L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "перо", "pero" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3814L },
                column: "transcription",
                value: "chénfá");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3815L },
                column: "transcription",
                value: "kan-dash");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3818L },
                column: "transcription",
                value: "minna");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 3819L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "pimiento", "piˈmjento" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3829L },
                column: "transcription",
                value: "enjireru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3830L },
                column: "transcription",
                value: "pa-fa-su");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3830L },
                column: "transcription",
                value: "bǐyǎn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3832L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "周期", "shūki" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3833L },
                column: "transcription",
                value: "yǒngzhǔ de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 3833L },
                column: "transcription",
                value: "stasyā");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3834L },
                column: "transcription",
                value: "yǒngyǒu de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3839L },
                column: "transcription",
                value: "nedzukoi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3842L },
                column: "transcription",
                value: "shēng-gè");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 3842L },
                column: "transcription",
                value: "vaykti-tya");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3843L },
                column: "transcription",
                value: "qǐng jī");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3846L },
                column: "transcription",
                value: "setsu-to-ku suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3850L },
                column: "transcription",
                value: "dantai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 3850L },
                column: "transcription",
                value: "zah-zeh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3850L },
                column: "transcription",
                value: "jiān duàn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3851L },
                column: "transcription",
                value: "げんしょう (genshō)");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3853L },
                column: "transcription",
                value: "tɛtsugɛtsu-tekina");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3853L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "哲学", "zhé-xué" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3854L },
                column: "transcription",
                value: "zhēng-xué");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3855L },
                column: "transcription",
                value: "diān huà");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3859L },
                column: "transcription",
                value: "pái zhao");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3860L },
                column: "transcription",
                value: "xiǎng yíng shī");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3861L },
                column: "transcription",
                value: "xiāng yìng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3863L },
                column: "transcription",
                value: "buk-ki-te-ki-na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3864L },
                column: "transcription",
                value: "yi shen");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 3867L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "клин", "klin" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 3867L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "pointe", "pwant" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 3867L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "くさび", "kusabi" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 3867L },
                column: "transcription",
                value: "xuǎnzuò");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4009L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "वरीच", "va-reech" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 4016L },
                column: "transcription",
                value: "pri'emium");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4030L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "preside", "purezaido" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4032L },
                column: "transcription",
                value: "zong:tong:");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4032L },
                column: "transcription",
                value: "ra:sh.tra:p.ti:");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 4056L },
                column: "transcription",
                value: "asnovo'y");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4056L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "素数の", "sono'za no" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4060L },
                column: "transcription",
                value: "Zhǎng xiào");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4071L },
                column: "transcription",
                value: "si-renh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4076L },
                column: "transcription",
                value: "ˈproʊbəl");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4077L },
                column: "transcription",
                value: "probəˈbləmenˈte");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4082L },
                column: "transcription",
                value: "j-en-poo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4082L },
                column: "transcription",
                value: "pra-kee-yaa");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4107L },
                column: "transcription",
                value: "bǐng-chéng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4108L },
                column: "transcription",
                value: "kaar-naa-mak");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4109L },
                column: "transcription",
                value: "bǐng-míng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4111L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "आगे बढ़ाना", "āge badhānā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 4112L },
                column: "transcription",
                value: "pwogwesist");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4115L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "予測する", "yokusuru" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4115L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "predecir", "pre-de-seer" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4116L },
                column: "transcription",
                value: "zhōng yǐng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4117L },
                column: "transcription",
                value: "hɛɐ̯vɔʁˈʃtɛːntʃt");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4119L },
                column: "transcription",
                value: "fer-shre-hen");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4120L },
                column: "transcription",
                value: "āśājnak");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 4123L },
                column: "transcription",
                value: "anzitee");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4123L },
                column: "transcription",
                value: "urusu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 4125L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "distinctif", "dis-tin-ktiv" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4125L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "articulado", "ar-tee-ku-lah-do" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4125L },
                column: "transcription",
                value: "ausgesprochen");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4127L },
                column: "transcription",
                value: "proh-pahn-dah");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4128L },
                column: "transcription",
                value: "tekudasai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4129L },
                column: "transcription",
                value: "seishiku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4136L },
                column: "transcription",
                value: "chee-shou");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4137L },
                column: "transcription",
                value: "abhiojak");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4147L },
                column: "transcription",
                value: "pras-ta-ta-ka-ree");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4151L },
                column: "transcription",
                value: "teːiːkiː suːru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4151L },
                column: "transcription",
                value: "teh-guhng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4154L },
                column: "transcription",
                value: "gōng-yíng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4163L },
                column: "transcription",
                value: "ishin");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4165L },
                column: "transcription",
                value: "shuppatsu suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4165L },
                column: "transcription",
                value: "fa-boo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4173L },
                column: "transcription",
                value: "ōgu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4176L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "púber", "pu'ber" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4181L },
                column: "transcription",
                value: "poo-ree-ta-re");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4185L },
                column: "transcription",
                value: "anusaarn karnaa");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4192L },
                column: "transcription",
                value: "kvalifiˌt");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4195L },
                column: "transcription",
                value: "kan-ta-deed");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4196L },
                column: "transcription",
                value: "jee-dao");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4197L },
                column: "transcription",
                value: "josai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4197L },
                column: "transcription",
                value: "kœ:nɪn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4201L },
                column: "transcription",
                value: "xun wen");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4202L },
                column: "transcription",
                value: "wen2 juan4");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4203L },
                column: "transcription",
                value: "dài miào");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4211L },
                column: "transcription",
                value: "watanashi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4214L },
                column: "transcription",
                value: "yīn yòng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 4216L },
                column: "transcription",
                value: "sarbovat'sya");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4223L },
                column: "transcription",
                value: "fúfǎn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4224L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "उत्तराधिकार", "ut-ta-ra-di-kr" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 4227L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "rafale", "rafal" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4228L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "saquear", "sakyar" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4229L },
                column: "transcription",
                value: "tie guan");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4229L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "पुल", "pul" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4233L },
                column: "transcription",
                value: "agasu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4234L },
                column: "transcription",
                value: "koond-guhng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4236L },
                column: "transcription",
                value: "tsoofˈɛlɪç");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4237L },
                column: "transcription",
                value: "hōgen");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4237L },
                column: "transcription",
                value: "райhsвайte");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4238L },
                column: "transcription",
                value: "ojibu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4238L },
                column: "transcription",
                value: "ghuumaanaa");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4241L },
                column: "transcription",
                value: "klasifikatsyon");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4245L },
                column: "transcription",
                value: "kyūjitsu ni");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4247L },
                column: "transcription",
                value: "shao chang");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4249L },
                column: "transcription",
                value: "zahhts");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4251L },
                column: "transcription",
                value: "murashika");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4251L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "bastante", "basˈtante" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4252L },
                column: "transcription",
                value: "reйтиṅ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4256L },
                column: "transcription",
                value: "xiàn yīn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4259L },
                column: "transcription",
                value: "ha-en-sū-ru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4260L },
                column: "transcription",
                value: "ha-n-no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4260L },
                column: "transcription",
                value: "fa-nyin");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4262L },
                column: "transcription",
                value: "yu-ku-sha");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4263L },
                column: "transcription",
                value: "qing-rén");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4267L },
                column: "transcription",
                value: "shi-an-de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4268L },
                column: "transcription",
                value: "shi-yen");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4277L },
                column: "transcription",
                value: "hái lǐ de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4283L },
                column: "transcription",
                value: "Omoidasu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4295L },
                column: "transcription",
                value: "shiru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4296L },
                column: "transcription",
                value: "su-i-shi-ru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4302L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "再計する", "saika ke suru" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4324L },
                column: "transcription",
                value: "karu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4338L },
                columns: new[] { "text", "transcription" },
                values: new object[] { " регулярно", "zhèngdào dì" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4347L },
                column: "transcription",
                value: "zhuī-jué");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4348L },
                column: "transcription",
                value: "zhuī-jué");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4377L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "remarkable", "hɪ.mɐ.zu.kɜ" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 4378L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "замечательно (zamechatel'no)", "zache-ta-tel-na" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 4378L },
                column: "text",
                value: "remarquablement (remarquablement)");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4378L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "驚くほどに (amaraku hodo ni)", "a-ma-ru-ku ho-do ni" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4382L },
                column: "transcription",
                value: "ri-ma-in-da-");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4388L },
                column: "transcription",
                value: "pristh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4392L },
                column: "transcription",
                value: "re-pah-roor");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4394L },
                column: "transcription",
                value: "kurikae");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4399L },
                column: "transcription",
                value: "huī-yuè");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 4423L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "похож(еть)", "pahoh-zh(e)t'" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4423L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "似る (nirū)", "nee-roo" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4426L },
                column: "transcription",
                value: "yuè dìng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4428L },
                column: "transcription",
                value: "teiaku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4428L },
                column: "transcription",
                value: "voenung");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4433L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "辞任", "sairen" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4435L },
                column: "transcription",
                value: "di-kâng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4436L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "抵抗", "teikō" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4486L },
                column: "transcription",
                value: "mū isuru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4501L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "timo", "ti-mo" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4502L },
                column: "transcription",
                value: "si-lie");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4506L },
                column: "transcription",
                value: "fā miǎn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4507L },
                column: "transcription",
                value: "mǎnghǎo de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4520L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "rama", "rah-mah" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4520L },
                column: "transcription",
                value: "gun1");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4521L },
                column: "transcription",
                value: "yakusō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4538L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "चार", "chaar" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4539L },
                column: "transcription",
                value: "lüu xian");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4540L },
                column: "transcription",
                value: "reh-gell-mahs");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4545L },
                column: "transcription",
                value: "piáo liú de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4546L },
                column: "transcription",
                value: "póu jiāo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4574L },
                column: "transcription",
                value: "shuǐtǒu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4575L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "Heilig", "Hайлиh" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4579L },
                column: "transcription",
                value: "cuō-shòu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4581L },
                column: "transcription",
                value: "zhǒng yí");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4601L },
                column: "transcription",
                value: "chou-wen");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4603L },
                column: "transcription",
                value: "dharaana");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4607L },
                column: "transcription",
                value: "qing-jing");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4608L },
                column: "transcription",
                value: "chēng-qíng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4616L },
                column: "transcription",
                value: "kai-shih");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4617L },
                column: "transcription",
                value: "kai-shí de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4627L },
                column: "text",
                value: "bildschirmfüllen");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4628L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "Abschirmung", "apˈʃɪʁmʊŋ" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4631L },
                column: "transcription",
                value: "kiaku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4651L },
                column: "transcription",
                value: "ahp-shtit");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 4654L },
                column: "transcription",
                value: "biːzאָpásnyɪ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4654L },
                column: "transcription",
                value: "안zen'na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 4655L },
                column: "transcription",
                value: "abaespichivat'");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4655L },
                column: "transcription",
                value: "hākō suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4661L },
                column: "transcription",
                value: "hao xiang");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4673L },
                column: "transcription",
                value: "fā sòu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4679L },
                column: "transcription",
                value: "min-gan");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4680L },
                column: "transcription",
                value: "min-gan-xing");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4700L },
                column: "transcription",
                value: "darshyan");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4710L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "严重", "zhèn yào" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4712L },
                column: "transcription",
                value: "se-i");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4733L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "透ける", "tokeru" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4752L },
                column: "transcription",
                value: "saței");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4760L },
                column: "transcription",
                value: "tanpi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4772L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "उबालना", "ubālnā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4780L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "निहाई", "nighāī" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4781L },
                column: "transcription",
                value: "shikkei");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 4788L },
                column: "transcription",
                value: "enporton");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4789L },
                column: "transcription",
                value: "signifikamente");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 4793L },
                column: "transcription",
                value: "glupo-y");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4796L },
                column: "transcription",
                value: "siˈmiɾ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 4797L },
                column: "transcription",
                value: "sXodstvo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 4797L },
                column: "transcription",
                value: "sililityd");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4797L },
                column: "transcription",
                value: "ruchōsei");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4798L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "similmente", "simi-en-te" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4810L },
                column: "transcription",
                value: "ka-shi-a");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4811L },
                column: "transcription",
                value: "el 'ahn-toh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4812L },
                column: "transcription",
                value: "so'lterO");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4831L },
                column: "transcription",
                value: "abiloh-soh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4832L },
                column: "transcription",
                value: "hadagi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4835L },
                column: "transcription",
                value: "tou1 gu3");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4835L },
                column: "transcription",
                value: "khopDii");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4837L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "ぶつける", "butsuku" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4844L },
                column: "transcription",
                value: "pyan");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4855L },
                column: "transcription",
                value: "mà");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 4856L },
                column: "transcription",
                value: "zametlyat'");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4856L },
                column: "transcription",
                value: "okosaseru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4857L },
                column: "transcription",
                value: "yu-ku-ru-ku");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4858L },
                column: "transcription",
                value: "ksiǎo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4862L },
                column: "transcription",
                value: "geh-roooh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4862L },
                column: "transcription",
                value: "chi-way");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4864L },
                column: "transcription",
                value: "egaō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4865L },
                column: "transcription",
                value: "eigaō ni suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4867L },
                column: "transcription",
                value: "dhūmrapān karānā");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4878L },
                column: "transcription",
                value: "iseki-ken");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4879L },
                column: "transcription",
                value: "ahs-chen-dehhr");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4881L },
                column: "transcription",
                value: "shē-huì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4883L },
                column: "transcription",
                value: "shê-huì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4886L },
                column: "transcription",
                value: "ruan-jian");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4892L },
                column: "transcription",
                value: "shi-ren");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4896L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "独的", "doo-yeh" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4897L },
                column: "transcription",
                value: "du-tsoh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4897L },
                column: "transcription",
                value: "ek-kal");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4903L },
                column: "transcription",
                value: "deh al-goo-nah mah-reh-rah");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 4907L },
                column: "transcription",
                value: "ee-nod-nah");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4907L },
                column: "transcription",
                value: "to-to");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 4916L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "Oh là là!", "Oh la la!" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4916L },
                column: "transcription",
                value: "oh yuh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4919L },
                column: "transcription",
                value: "tamá");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4919L },
                column: "transcription",
                value: "Líng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4929L },
                column: "transcription",
                value: "sam-prah-bu-ta");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 4933L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "sauter", "so-tay" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4940L },
                column: "transcription",
                value: "visaheshṭa");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4941L },
                column: "transcription",
                value: "zhuan-jia");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4941L },
                column: "transcription",
                value: "vish-esh-asht");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4942L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "विशेषज्ञता", "vish-esh-tas-ta" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4943L },
                column: "transcription",
                value: "zhuan-yeh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4943L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "विशेषज्ञ", "vishishtajña" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4944L },
                column: "transcription",
                value: "es-pe-si-e");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4945L },
                column: "transcription",
                value: "tokubetsu no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 4947L },
                column: "transcription",
                value: "speɦsɦfɦkɦsɦfɦkɦsɦfɦkɦsɦfɦkɦsɦfɦkɦsɦfɦkɦsɦfɦkɦsɦfɦkɦsɦfɦkɦsɦfɦkɦsɦfɦkɦsɦfɦkɦsɦfɦkɦsɦfɦkɦsɦfɦkɦsɦfɦkɦsɦfɦkɦsɦfɦkɦsɦfɦkɦsɦfɦkɦsɦfɦkɦsɦfɦkɦsɦfɦkɦsɦfɦkɦsɦfɦkɦsɦfɦkɦsɦfɦkɦsɦfɦkɦsɦfɦkɦsɦfɦkɦsɦfɦkɦsɦfɦkɦsɦfɦkɦs");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 4949L },
                column: "transcription",
                value: "mwyestra");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4953L },
                column: "transcription",
                value: "fēn-qì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4957L },
                column: "transcription",
                value: "sù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4969L },
                column: "transcription",
                value: "ghoṛan");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 4971L },
                column: "transcription",
                value: "pozvonochik");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4971L },
                column: "transcription",
                value: "virbelzāule");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4973L },
                column: "transcription",
                value: "aadhyAtmik");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 4974L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "vengeance", "vã-nãss" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 4974L },
                column: "transcription",
                value: "akuu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 4974L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "Neid", "nāyt" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4974L },
                column: "transcription",
                value: "tirkār");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4980L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "पर्देjší", "pardeshī" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4981L },
                column: "transcription",
                value: "nǚ huìyán rén");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4989L },
                column: "transcription",
                value: "pahāncānā");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 4991L },
                column: "transcription",
                value: "suprud/suprudga");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 4991L },
                column: "transcription",
                value: "jaan saathī");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 4998L },
                column: "transcription",
                value: "wèi dú");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5000L },
                column: "transcription",
                value: "bharg");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 5009L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "подготавливать", "padgatavlivat'" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 5009L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "préparer", "prepare" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5009L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "準備する", "junbi suru" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5011L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "शट", "shat" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5012L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "खोपड़ी", "khopṛī" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5013L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "ट stamp", "ṭamp" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 5021L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "brillar", "bree-yar" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 5021L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "beseenken", "beh-sehn-ken" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 5027L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "estatal", "es-ta-tal" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 5027L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "gemütlich", "ge-myut-lich" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5027L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "情绪", "qing-xu" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5043L },
                column: "transcription",
                value: "kītsu na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5044L },
                column: "transcription",
                value: "sōteiwu suru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5044L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "निलकाना", "nila-kaa-naa" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 5046L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "тормозить", "tormozit'" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 5046L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "s'arrêter", "seta-re" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5046L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "止める", "to-me-ru" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5050L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "लकीर", "lakīr" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 5052L },
                column: "transcription",
                value: "klo:bɪç");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5053L },
                column: "transcription",
                value: "katakoi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 5083L },
                column: "transcription",
                value: "padchёrvivat'");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5098L },
                column: "transcription",
                value: "jē gou də");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5109L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "छटपटाना", "chaṭapānā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5126L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "बदलाव", "ba-dlaav" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5127L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "बदला", "bad-la" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 5128L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "Ersatz", "ˈɛɐ̯tsɛs" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5260L },
                column: "transcription",
                value: "neru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5269L },
                column: "transcription",
                value: "sikhnā");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5299L },
                column: "transcription",
                value: "ねんき");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5302L },
                column: "transcription",
                value: "tu-erm-in-deh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5303L },
                column: "transcription",
                value: "térmín");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5303L },
                column: "transcription",
                value: "taʁmiɳal");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5312L },
                column: "transcription",
                value: "khong-bu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 5334L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "определённый артикль не используется", "aprazany definity artikl ne ispol'zuyetsya" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5334L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "定冠詞 (teikan-shi)", "teekan-shi" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5334L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "这", "zhɛ:" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5334L },
                column: "transcription",
                value: "ja:h");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5335L },
                column: "transcription",
                value: "gikijō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 5340L },
                column: "transcription",
                value: "oz");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5343L },
                column: "transcription",
                value: "si-te-shi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5352L },
                column: "transcription",
                value: "shite arimashita");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5363L },
                column: "transcription",
                value: "kǒu kǎo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5372L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "though　（～でも）", "demo" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5374L },
                column: "transcription",
                value: "kanegae-sareru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5381L },
                column: "transcription",
                value: "kyōka");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5384L },
                column: "transcription",
                value: "nod");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5387L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "Throughout", "juːˈaʊt" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5390L },
                column: "transcription",
                value: "shichizu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 5391L },
                column: "transcription",
                value: "zhuvi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5405L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "計る (kazaru)", "ka-za-ru" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5410L },
                column: "transcription",
                value: "ṭipa");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5414L },
                column: "transcription",
                value: "ti-ao");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5415L },
                column: "transcription",
                value: "naokeru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5424L },
                column: "transcription",
                value: "kānjō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 5436L },
                column: "transcription",
                value: "ozzi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5442L },
                column: "transcription",
                value: "wada");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5445L },
                column: "transcription",
                value: "n-ge-ru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5450L },
                column: "transcription",
                value: "chōo-mō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5454L },
                column: "transcription",
                value: "cān gùn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5456L },
                column: "transcription",
                value: "yú-kè");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5456L },
                column: "transcription",
                value: "paryatanak");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5481L },
                column: "transcription",
                value: "r̥eʦu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5490L },
                column: "transcription",
                value: "hengaru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5499L },
                column: "transcription",
                value: "pārdareshī");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 5525L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "milliard", "mee-yar" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5530L },
                column: "transcription",
                value: "bureau");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 5530L },
                column: "transcription",
                value: "Troopə");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5530L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "टैबड़", "ṭebaṛ" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5538L },
                column: "transcription",
                value: "honto");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5548L },
                column: "transcription",
                value: "maṅgلوار");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 5550L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "настройка", "nastrójka" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 5550L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "accord", "akor" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 5550L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "afinación", "a-fee-na-thyohn" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5560L },
                column: "transcription",
                value: "futtsu no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5577L },
                column: "transcription",
                value: "oshu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5578L },
                column: "transcription",
                value: "i-ro-ko-ji ga wa-rai");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5591L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "अंदरwear", "aṇḍar-viār" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 5599L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "к сожалению (k сожалению)", "k zhalost'yu" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5599L },
                column: "text",
                value: "残念ながら (zannen nagara)");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5606L },
                column: "transcription",
                value: "lye-uhn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5609L },
                column: "transcription",
                value: "bokutan-teki na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5611L },
                column: "transcription",
                value: "dah-hay-dah-khwah");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5612L },
                column: "transcription",
                value: "meeei");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5613L },
                column: "transcription",
                value: "chú ruǎn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5614L },
                column: "transcription",
                value: "ke vipakṣ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5616L },
                column: "transcription",
                value: "hi-zu-na");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5617L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "अनुपयुक्त", "anu-pyukt" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5638L },
                column: "transcription",
                value: "としの");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5638L },
                column: "transcription",
                value: "shahara");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5639L },
                column: "transcription",
                value: "usu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5656L },
                column: "transcription",
                value: "zī hū");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5658L },
                column: "transcription",
                value: "yǒu xióng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5659L },
                column: "transcription",
                value: "yǒu xióng xìng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5661L },
                column: "transcription",
                value: "yoʊ ˈvɑːljuː");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5663L },
                column: "transcription",
                value: "ping-ga");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5668L },
                column: "transcription",
                value: "biàn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 5670L },
                column: "transcription",
                value: "raznóvídie");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5672L },
                column: "transcription",
                value: "biàn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5677L },
                column: "transcription",
                value: "mǎng-hěn");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5678L },
                column: "transcription",
                value: "mǎnghǎo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5679L },
                column: "transcription",
                value: "gàngdì");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5680L },
                column: "transcription",
                value: "kūtoō no");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5686L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "垂直 (垂直)", "seiki" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5686L },
                column: "transcription",
                value: "chū-fēi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5689L },
                column: "transcription",
                value: "rong-qi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5689L },
                column: "transcription",
                value: "jhaaz");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5690L },
                column: "transcription",
                value: "taiketsu gunjin");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5690L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "सैनिक", "Sainik" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5692L },
                column: "transcription",
                value: "kei-xing");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5694L },
                column: "transcription",
                value: "aku-hesi");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 5694L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "Tugend", "ˈtuːɡənt" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5698L },
                column: "transcription",
                value: "bee-deh-toh");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5698L },
                column: "transcription",
                value: "shi-pin");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5701L },
                column: "transcription",
                value: "shō-cha");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5705L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "उल्लंघन", "ulān-ghan" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 5706L },
                column: "transcription",
                value: "vi'oʊˈlɑːson");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5706L },
                column: "transcription",
                value: "ulān-ghan");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5708L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "暴力", "bǎo lì" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 5709L },
                column: "transcription",
                value: "vərˈtjuəl");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5711L },
                column: "transcription",
                value: "wèi-rǔ");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5711L },
                column: "transcription",
                value: "vaira-sus");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 5718L },
                column: "transcription",
                value: "vizh-oo-al");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5718L },
                column: "transcription",
                value: "shih-zhuh-aw-dih");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5721L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "口語的な", "こうごてきな" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 5721L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "vocales", "boh-kah-lehs" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5731L },
                column: "transcription",
                value: "zeika-sei");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5731L },
                column: "transcription",
                value: "cuō-róu-xìng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5732L },
                column: "transcription",
                value: "cuō-ruò");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5734L },
                column: "transcription",
                value: "dăi dài");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5735L },
                column: "transcription",
                value: "machu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5735L },
                column: "transcription",
                value: "dài tí");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5738L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "तैरना", "ṭairnā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 5744L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "servicio", "ser-b-yo" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5760L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "बरબાદ करना", "bar-bād kar-nā" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5761L },
                column: "transcription",
                value: "uchideomote");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5773L },
                column: "transcription",
                value: "fukō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5783L },
                column: "transcription",
                value: "kharpatār");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5787L },
                column: "transcription",
                value: "tansu");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5790L },
                column: "transcription",
                value: "svāgat yōg");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5798L },
                column: "transcription",
                value: "ida");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5811L },
                column: "transcription",
                value: "ksiǎo mài");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5812L },
                column: "transcription",
                value: "saru");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5818L },
                column: "text",
                value: "whereは、文法的な接続詞としては存在しませんが、場所を示す疑問詞として「どこ」 (doko) に相当します。場所を表す際に、文法的には指示詞や疑問詞の一部として機能します。");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 5826L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "lamento", "lah-men-toh" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 5828L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "плескать", "pleskat'" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5828L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "打ち", "uchi" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 5828L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "azar", "ah-thahr" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 5829L },
                column: "transcription",
                value: "susúrrō");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 5840L },
                column: "transcription",
                value: "dei kien");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5843L },
                column: "transcription",
                value: "fāngmiàn de");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5846L },
                column: "transcription",
                value: "mibei-nin");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5850L },
                column: "transcription",
                value: "yī shēng dòng wù");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5851L },
                column: "transcription",
                value: "iyūgan");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5853L },
                column: "transcription",
                value: "yande");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5859L },
                column: "transcription",
                value: "khin-dee");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 5862L },
                column: "transcription",
                value: "gahan-dor");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5867L },
                column: "transcription",
                value: "kami");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5897L },
                column: "transcription",
                value: "rúcóng");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5904L },
                column: "transcription",
                value: "puːd͡ʒɑː");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5905L },
                column: "transcription",
                value: "puːdʒɑː");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 5917L },
                column: "transcription",
                value: "ãb.blé");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 8L, 5926L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "बर्गा", "barga" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 6L, 5938L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "ertragen", "ehr-trah-gen" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 7L, 5938L },
                column: "transcription",
                value: "chan-shen");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 5944L },
                column: "transcription",
                value: "tyoo");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 5L, 5945L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "te", "te" });
        }
    }
}
