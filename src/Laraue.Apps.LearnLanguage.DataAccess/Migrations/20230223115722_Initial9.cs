using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Laraue.LearnLanguage.DataAccess.Migrations
{
    public partial class Initial9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "languages",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "word_group_words",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    serial_number = table.Column<long>(type: "bigint", nullable: false),
                    word_group_id = table.Column<long>(type: "bigint", nullable: false),
                    word_translation_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_word_group_words", x => x.id);
                    table.ForeignKey(
                        name: "fk_word_group_words_word_groups_word_group_id",
                        column: x => x.word_group_id,
                        principalTable: "word_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_word_group_words_word_translations_word_translation_id",
                        column: x => x.word_translation_id,
                        principalTable: "word_translations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "word_translation_states",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    learn_state = table.Column<byte>(type: "smallint", nullable: false),
                    view_count = table.Column<int>(type: "integer", nullable: false),
                    learned_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    word_translation_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_word_translation_states", x => x.id);
                    table.ForeignKey(
                        name: "fk_word_translation_states_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_word_translation_states_word_translations_word_translation_",
                        column: x => x.word_translation_id,
                        principalTable: "word_translations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "languages",
                keyColumn: "id",
                keyValue: 1L,
                column: "code",
                value: "ru");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 17L,
                column: "translation",
                value: "оскорблять, бранить, брань | злоупотреблять | насилие, домогательство");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 22L,
                column: "translation",
                value: "случайность | происшествие, напр. ДТП");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 29L,
                column: "translation",
                value: "счёт (в банке) | отчёт");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 57L,
                column: "translation",
                value: "принимать, перенимать | усыновить или взять (животное)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 72L,
                column: "translation",
                value: "воздушный | антенна");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 73L,
                column: "translation",
                value: "дело, занятие | роман, любовная история");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 84L,
                column: "translation",
                value: "век, эпоха | возраст");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 180L,
                column: "translation",
                value: "появиться | казаться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 183L,
                column: "translation",
                value: "применять, применяться | обращаться (с заявлением)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 189L,
                column: "translation",
                value: "присвоить | подходящий, присущий");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 214L,
                column: "translation",
                value: "статья | вещь, изделие");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 241L,
                column: "translation",
                value: "принимать на себя | предпогалать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 289L,
                column: "translation",
                value: "бакалавр | холостяк");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 295L,
                column: "translation",
                value: "происхождение, предыстория | фон");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 317L,
                column: "translation",
                value: "пластина, брусок, прут и т. д. | загораживать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 324L,
                column: "translation",
                value: "кора | лаять");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 334L,
                column: "translation",
                value: "бита | летучая мышь");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 353L,
                column: "translation",
                value: "балка, перекладина | луч");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 355L,
                column: "translation",
                value: "рожать | нести, втч перен.");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 358L,
                column: "translation",
                value: "победить | бить");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 402L,
                column: "translation",
                value: "счёт (к оплате) | банкнота");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 421L,
                column: "translation",
                value: "дуновение, порыв | взрыв, взрывать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 434L,
                column: "translation",
                value: "кусок, глыба и т. д. | квартал");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 441L,
                column: "translation",
                value: "дуть | удар");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 444L,
                column: "translation",
                value: "взорвать | накачивать, надувать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 449L,
                column: "translation",
                value: "совет, коллегия | доска | борт, подниматься на борт");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 456L,
                column: "translation",
                value: "связь, узы, соединение | обязательство, облигация");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 479L,
                column: "translation",
                value: "всплеск, приступ | бой, поединок");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 480L,
                column: "translation",
                value: "бант, бабочка | лук | поклон, наклоняться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 489L,
                column: "translation",
                value: "ветвь | филиал, ответвление");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 502L,
                column: "translation",
                value: "вспыхнуть, разразиться | сбежать, вырваться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 527L,
                column: "translation",
                value: "поднять тему | воспитывать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 558L,
                column: "translation",
                value: "шишка, выпуклость | удар, ударять");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 576L,
                column: "translation",
                value: "торец, зад | задница");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 615L,
                column: "translation",
                value: "ёмкость, вместимость | способность, возможность");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 624L,
                column: "translation",
                value: "забота, уход | переживать, интересоваться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 637L,
                column: "translation",
                value: "случай, дело | ящик, футляр, чехол");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 640L,
                column: "translation",
                value: "бросать, метать | отливать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 645L,
                column: "translation",
                value: "становиться популярным | внезапно понять");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 686L,
                column: "translation",
                value: "заряжать, нагружать | обвинять | плата");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 699L,
                column: "translation",
                value: "посмотреть, заценить | освободить номер");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 710L,
                column: "translation",
                value: "грудь (грудная клетка) | сундук");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 745L,
                column: "translation",
                value: "требовать, претендовать | утверждать, претендовать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 772L,
                column: "translation",
                value: "отсекать, обрезать | зажим, зажимать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 790L,
                column: "translation",
                value: "автобус, вагон, телега | тренер");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 795L,
                column: "translation",
                value: "покрывать | пальто");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 819L,
                column: "translation",
                value: "идти вместе | продвигаться (о работе)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 820L,
                column: "translation",
                value: "найти, заполучить | зайти");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 824L,
                column: "translation",
                value: "выйти, получиться | отвалиться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 826L,
                column: "translation",
                value: "выступить, заявить | выходить (напр. об альбоме)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 829L,
                column: "translation",
                value: "очнуться | доходить до");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 833L,
                column: "translation",
                value: "произойти или появиться | приближаться (о событии)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 845L,
                column: "translation",
                value: "приверженность | обязательство");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 847L,
                column: "translation",
                value: "общий | обычный, распространённый");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 862L,
                column: "translation",
                value: "допонять, дополнение | набор, состав, комплект");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 884L,
                column: "translation",
                value: "состояние | условие");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 887L,
                column: "translation",
                value: "дать, принести, присудить | совещаться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 909L,
                column: "translation",
                value: "рассматривать, учитывать | считать чем-либо");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 973L,
                column: "translation",
                value: "считаться, иметь значение | считать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 975L,
                column: "translation",
                value: "противостоять, противоположный | стойка, прилавок");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 983L,
                column: "translation",
                value: "суд | двор (королевский) | игровая площадка");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1055L,
                column: "translation",
                value: "узда, обуздать, сдержать | бордюр или обочина");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1060L,
                column: "translation",
                value: "текущий, актуальный | ток, поток, течение");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1067L,
                column: "translation",
                value: "заказной, индивидуальный | обычай, привычка");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1085L,
                column: "translation",
                value: "тире, чёрточка | бросать, бросаться | разрушить (перен.)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1113L,
                column: "translation",
                value: "отказаться, отклонить | снижаться, снижение");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1132L,
                column: "translation",
                value: "степень (во всех значениях) | градус");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1140L,
                column: "translation",
                value: "доставлять | рожать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1142L,
                column: "translation",
                value: "требовать | спрос");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1168L,
                column: "translation",
                value: "пустыня | бросать, оставлять");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1222L,
                column: "translation",
                value: "прямой (обычн. перен.знач.) | направлять");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1247L,
                column: "translation",
                value: "тарелка или миска | блюдо");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1252L,
                column: "translation",
                value: "прогонять, посылать, увольнять | отклонить, отбросить");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1262L,
                column: "translation",
                value: "располагать, распоряжаться | избавиться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1296L,
                column: "translation",
                value: "домашний | внутренний (о политике)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1311L,
                column: "translation",
                value: "тяга, сквозняк | проект, черновик, набросок");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1329L,
                column: "translation",
                value: "водить машину | двигать, гнать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1332L,
                column: "translation",
                value: "падать, ронять | капля");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1351L,
                column: "translation",
                value: "немой | тупой");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1353L,
                column: "translation",
                value: "сваливать, сбрасывать свалка | бросать (парня/девушку)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1388L,
                column: "translation",
                value: "либо | тоже (не) | любой из двух");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1414L,
                column: "translation",
                value: "использовать | нанимать на работу");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1451L,
                column: "translation",
                value: "давать название | давать право (по заслугам)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1505L,
                column: "translation",
                value: "исполнить | казнить");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1510L,
                column: "translation",
                value: "исчерпывать, истощать | выхлопные газы");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1553L,
                column: "translation",
                value: "сооружение, объект | лёгкость, удобство");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1560L,
                column: "translation",
                value: "слабый, неуловимый | обморок, падать в обморок");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1561L,
                column: "translation",
                value: "светлый | справедливый, честный");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1570L,
                column: "translation",
                value: "вестись | влюбляться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1582L,
                column: "translation",
                value: "необычный, причудливый, модный | представлять, полагать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1588L,
                column: "translation",
                value: "мода | стиль, образ, манер");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1594L,
                column: "translation",
                value: "недостаток, неисправность | вина, ошибка");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1611L,
                column: "translation",
                value: "парень, человек | товарищ по чему-либо");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1641L,
                column: "translation",
                value: "штраф | тонкий | хороший");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1665L,
                column: "translation",
                value: "плоский, ровный | квартира");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1675L,
                column: "translation",
                value: "короткое резкое движение | фильм (разг.)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1678L,
                column: "translation",
                value: "полёт, рейс | бегство");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1687L,
                column: "translation",
                value: "пол | этаж");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1698L,
                column: "translation",
                value: "промывать, смывать | румянец, порозоветь");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1706L,
                column: "translation",
                value: "расстаривать, разрушать | фольга");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1730L,
                column: "translation",
                value: "ковать | подделывать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1733L,
                column: "translation",
                value: "бывший | первый (из названных)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1739L,
                column: "translation",
                value: "состояние (деньги) | счастье, удача, судьба");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1741L,
                column: "translation",
                value: "приёмный (ребёнок) | способствовать, питать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1795L,
                column: "translation",
                value: "предоставлять | обставлять, меблировать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1860L,
                column: "translation",
                value: "раздавать, дарить | выдать (раскрыть)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1864L,
                column: "translation",
                value: "отказаться, сдаться | бросить (привычку)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1891L,
                column: "translation",
                value: "быть проданным за | выбирать, предпочитать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1893L,
                column: "translation",
                value: "сработать | отключиться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1894L,
                column: "translation",
                value: "происходить | продолжаться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1912L,
                column: "translation",
                value: "оценка | класс, уровень");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1926L,
                column: "translation",
                value: "могила | серьёзный");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1942L,
                column: "translation",
                value: "крошка, песок, гравий | твёрдость, стойкость");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1948L,
                column: "translation",
                value: "валовой, грязный | грубый (во всех смыслах)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1950L,
                column: "translation",
                value: "становиться | расти или выращивать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1963L,
                column: "translation",
                value: "разрыв, пропасть | залив");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1975L,
                column: "translation",
                value: "град | окликнуть, привлечь внимание | приветствовать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1992L,
                column: "translation",
                value: "рукоятка | управляться, обращаться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2074L,
                column: "translation",
                value: "ударить, удар | попасть, достичь");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2083L,
                column: "translation",
                value: "оставаться на линии | держаться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2094L,
                column: "translation",
                value: "капот, кожух | капюшон");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2097L,
                column: "translation",
                value: "потрахаться | подключить, смонтировать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2108L,
                column: "translation",
                value: "хозяин, быть хозяином | множество");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2128L,
                column: "translation",
                value: "горб, горбиться | догадка, предчуствие");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2137L,
                column: "translation",
                value: "толкаться, торопиться | нечестно добыть (амер.)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2145L,
                column: "translation",
                value: "больной | дурной, нехороший");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2242L,
                column: "translation",
                value: "честность, порядочность | целостность");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2268L,
                column: "translation",
                value: "представить, познакомить | ввести (в употребление)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2277L,
                column: "translation",
                value: "вовлекать, увлекать | содержать в себе (процесс)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2279L,
                column: "translation",
                value: "утюг, гладить | железо, железный");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2282L,
                column: "translation",
                value: "издать, выпустить, выпуск | вопрос, проблема");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2296L,
                column: "translation",
                value: "дёргать, резкое движение | придурок");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2297L,
                column: "translation",
                value: "струя | реактивный двигатель/самолёт");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2303L,
                column: "translation",
                value: "сустав, шарнир, стык и т. д. | совместный, объединённый");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2336L,
                column: "translation",
                value: "шутить, разыгрывать | ребёнок");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2340L,
                column: "translation",
                value: "добрый | тип, вид");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2375L,
                column: "translation",
                value: "упущение, оплошность | промежуток времени");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2382L,
                column: "translation",
                value: "поздний | покойный");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2458L,
                column: "translation",
                value: "строка | линия, ряд");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2461L,
                column: "translation",
                value: "бельё | льняная ткань");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2492L,
                column: "translation",
                value: "домик, поселиться, остановиться | подавать (документ)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2518L,
                column: "translation",
                value: "гостиная, холл, комната отдыха | расслабляться, бездельничать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2552L,
                column: "translation",
                value: "разобрать, понять | целоваться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2554L,
                column: "translation",
                value: "выдумать | помириться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2567L,
                column: "translation",
                value: "руководство, учебник | ручной");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2573L,
                column: "translation",
                value: "край, граница | маржа, накрутка");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2586L,
                column: "translation",
                value: "хозяин | овладеть (напр. искусством)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2589L,
                column: "translation",
                value: "соответствие, нечто соответствующее | спичка");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2592L,
                column: "translation",
                value: "вещество, материя | дело, вопрос | иметь значение");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2601L,
                column: "translation",
                value: "иметь в виду | означать | предназначать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2605L,
                column: "translation",
                value: "мера, мероприятие | измерять, измерение");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2652L,
                column: "translation",
                value: "мина | шахта, рудник");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2654L,
                column: "translation",
                value: "второстепенный, незначительный | несовершеннолетний");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2659L,
                column: "translation",
                value: "нищета | несчастье, страдание");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2660L,
                column: "translation",
                value: "скучать | пропускать, упустить");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2666L,
                column: "translation",
                value: "госпожа, хозяйка | любовница");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2678L,
                column: "translation",
                value: "плесень | форма, формировать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2679L,
                column: "translation",
                value: "крот | родинка");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2699L,
                column: "translation",
                value: "монтировать, устанавливать | подниматься, забираться | гора");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2729L,
                column: "translation",
                value: "гвоздь, прибивать | ноготь");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2738L,
                column: "translation",
                value: "родной | местный, туземный");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2753L,
                column: "translation",
                value: "ни один из двух | тоже не");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2842L,
                column: "translation",
                value: "масло | нефть");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2867L,
                column: "translation",
                value: "порядок, упорядочивать | заказ, заказывать | приказ");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2895L,
                column: "translation",
                value: "выдающийся | неоплаченный, нерешённый");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2918L,
                column: "translation",
                value: "задолжать | быть обязанным чем-л.");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2924L,
                column: "translation",
                value: "пачка, связка, колода, и т. д. | упаковывать, собирать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2925L,
                column: "translation",
                value: "подушечка пальца, лапы | блокнот | панель, клавиатура");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2946L,
                column: "translation",
                value: "роль | часть, разделять(ся)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2963L,
                column: "translation",
                value: "мимо | прошлый, прошедший");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2999L,
                column: "translation",
                value: "ровня, ровесник | вглядываться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3023L,
                column: "translation",
                value: "сохраниться | упорствовать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3038L,
                column: "translation",
                value: "прибрать | подобрать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3054L,
                column: "translation",
                value: "трубка | труба");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3059L,
                column: "translation",
                value: "подавать (мяч) | ставить (напр. палатку)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3065L,
                column: "translation",
                value: "ясный, очевидный | ровный, равнина | простой, незамысловатый");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3068L,
                column: "translation",
                value: "растение, сажать | завод, производство");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3077L,
                column: "translation",
                value: "залог, оставлять в залог | обещание, обязательство");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3080L,
                column: "translation",
                value: "план, чертёж | сюжет");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3091L,
                column: "translation",
                value: "смысл, суть | точка | очко | острие, кончик | пункт");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3097L,
                column: "translation",
                value: "полюс | шест, столб");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3125L,
                column: "translation",
                value: "фунт | долбить, толочь");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3156L,
                column: "translation",
                value: "настоящее (время) | присутствующий, в наличии");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3163L,
                column: "translation",
                value: "довольно-таки | приятный");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3182L,
                column: "translation",
                value: "исследовать, проверить | датчик, зонд");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3198L,
                column: "translation",
                value: "побуждать, подстрекать | быстрый, оперативный");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3210L,
                column: "translation",
                value: "вести, осуществлять | преследовать (законодательно)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3248L,
                column: "translation",
                value: "отвратить, отвлечь и т. д. | откладывать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3249L,
                column: "translation",
                value: "надеть | провести (мероприятие)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3250L,
                column: "translation",
                value: "потушить | обременять, стеснять");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3277L,
                column: "translation",
                value: "раса | гонка");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3287L,
                column: "translation",
                value: "растить (детей) | поднять, повысить");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3290L,
                column: "translation",
                value: "собраться, созвать (напр. армию) | оживать, приходить в себя");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3303L,
                column: "translation",
                value: "курс, тариф, ставка | показатель, уровень");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3321L,
                column: "translation",
                value: "разум, благоразумие | причина, мотив");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3326L,
                column: "translation",
                value: "квитанция | получение");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3330L,
                column: "translation",
                value: "перерыв | выемка, впадина");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3365L,
                column: "translation",
                value: "внимание, уважение | считать, рассматривать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3377L,
                column: "translation",
                value: "родственник | относительный");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3398L,
                column: "translation",
                value: "делать, придавать свойство | воздавать, оказывать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3420L,
                column: "translation",
                value: "запас, запасной, запасать | бронировать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3428L,
                column: "translation",
                value: "решиться, решимость | разрешить (ситуацию)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3435L,
                column: "translation",
                value: "остаток, остальное | отдых, отдыхать | покоиться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3502L,
                column: "translation",
                value: "камень, скала | качать, трясти");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3506L,
                column: "translation",
                value: "рулон, клубок, свиток и т. д. | катиться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3515L,
                column: "translation",
                value: "сменять, чередовать | вращать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3523L,
                column: "translation",
                value: "грести | ряд");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3534L,
                column: "translation",
                value: "правило | править");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3587L,
                column: "translation",
                value: "чешуя, шелуха | взбираться | масштаб, шкала");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3611L,
                column: "translation",
                value: "драка, схватка | карабкаться, продираться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3621L,
                column: "translation",
                value: "винт, ввинчивать | к чёрту");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3627L,
                column: "translation",
                value: "печать, запечатывать | тюлень");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3653L,
                column: "translation",
                value: "чувство, осознание | смысл, значение");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3656L,
                column: "translation",
                value: "предложение | приговор");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3663L,
                column: "translation",
                value: "служить | сидеть (в тюрьме) | подавать (блюдо)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3670L,
                column: "translation",
                value: "задержать | обойтись в (сумму)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3672L,
                column: "translation",
                value: "устроить, организовать | познакомить, свести");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3673L,
                column: "translation",
                value: "уладить | селиться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3685L,
                column: "translation",
                value: "тень | оттенок (яркости)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3687L,
                column: "translation",
                value: "вал, ось, стержень | шахта (напр. лифта)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3688L,
                column: "translation",
                value: "трясти | пожать (руки)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3694L,
                column: "translation",
                value: "делить, доля | разделять (напр. мнение)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3703L,
                column: "translation",
                value: "явный, полный, чистый | отвесный");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3710L,
                column: "translation",
                value: "сменить, сдвинуть | смена (на работе)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3717L,
                column: "translation",
                value: "стрелять | снимать, фотографировать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3753L,
                column: "translation",
                value: "вид, поле зрения | достопримечаетльность");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3754L,
                column: "translation",
                value: "знак | подпись, подписывать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3769L,
                column: "translation",
                value: "поскольку | с (какого-то времени)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3871L,
                column: "translation",
                value: "единственный | подошва");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3873L,
                column: "translation",
                value: "сплошной | твёрдый, крепкий");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3876L,
                column: "translation",
                value: "решение, ответ | раствор");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3892L,
                column: "translation",
                value: "пространство | космос");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3895L,
                column: "translation",
                value: "щадить, избавить | запасной, лишний | выделить, уделить");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3913L,
                column: "translation",
                value: "заклинание, чары | произносить (писать) по буквам");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3932L,
                column: "translation",
                value: "место | пятно | заметить, увидеть");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3937L,
                column: "translation",
                value: "прыгать | источник, проистекать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3943L,
                column: "translation",
                value: "квадрат, квадратный | площадь");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3958L,
                column: "translation",
                value: "сцена | стадия, ступень");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3962L,
                column: "translation",
                value: "стойка, кол, столб | ставка, делать ставку");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3964L,
                column: "translation",
                value: "красться, преследовать | стебель");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3965L,
                column: "translation",
                value: "задержаться, застопориться | палатка, ларёк");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3971L,
                column: "translation",
                value: "выступать за | обозначать (в сокращении)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3981L,
                column: "translation",
                value: "государство | состояние | заявить, отметить");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3984L,
                column: "translation",
                value: "оставаться | остановиться пожить");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4014L,
                column: "translation",
                value: "запас | акции");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4020L,
                column: "translation",
                value: "крыльцо со ступеньками (амер.) | наклоняться или сутулиться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4022L,
                column: "translation",
                value: "хранить, хранилище | магазин");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4029L,
                column: "translation",
                value: "застрять, сесть на мель | прядь, нить (об. скрученная)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4048L,
                column: "translation",
                value: "полоса, лента | снимать (обнажать)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4065L,
                column: "translation",
                value: "предмет, тема | подверженный, подвергать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4099L,
                column: "translation",
                value: "костюм, комплект | подходить, соответствовать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4115L,
                column: "translation",
                value: "поставлять, поставка | предложение");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4144L,
                column: "translation",
                value: "клясться | ругаться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4162L,
                column: "translation",
                value: "канцелярская кнопка, гвоздик | курс, линия поведения");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4163L,
                column: "translation",
                value: "принадлежности, снаряжение | взяться за что-л.");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4179L,
                column: "translation",
                value: "снять | взлететь");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4180L,
                column: "translation",
                value: "соревноваться, столкнуться | набрать (напр. рабочих)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4195L,
                column: "translation",
                value: "стучать | кран");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4216L,
                column: "translation",
                value: "храм | висок");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4220L,
                column: "translation",
                value: "иметь склонность | ухаживать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4225L,
                column: "translation",
                value: "срок, период | термин");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4228L,
                column: "translation",
                value: "отношения | условия, соглашение");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4246L,
                column: "translation",
                value: "толстый | густой");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4275L,
                column: "translation",
                value: "галочка, поставить галочку | клещ");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4280L,
                column: "translation",
                value: "галстук, завязка и т.п. | связывать, завязывать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4294L,
                column: "translation",
                value: "кончик, верхушка | совет, рекомендация");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4299L,
                column: "translation",
                value: "ткань | бумажная салфетка");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4319L,
                column: "translation",
                value: "связь, контакт | касаться, прикосновение");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4334L,
                column: "translation",
                value: "поезд | тренировать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4358L,
                column: "translation",
                value: "испытание, пробный | судебный процесс");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4376L,
                column: "translation",
                value: "багажник | ствол дерева | чемодан, сундук");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4381L,
                column: "translation",
                value: "тюбик | труба | метро (в Лондоне)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4388L,
                column: "translation",
                value: "мелодия, мотив | настраивать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4395L,
                column: "translation",
                value: "выключить | свернуть (с дороги)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4396L,
                column: "translation",
                value: "включить | заводить, возбуждать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4440L,
                column: "translation",
                value: "вертикальный, стоячий | честный");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4454L,
                column: "translation",
                value: "полный, абсолютный | издать, произнести");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4457L,
                column: "translation",
                value: "тщеславный, самолюбивый | напрасный, безрезультатный");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4471L,
                column: "translation",
                value: "свод, небосвод | хранилище, об. в подвале");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4485L,
                column: "translation",
                value: "обочина | грань, предел");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4489L,
                column: "translation",
                value: "сосуд | судно");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4521L,
                column: "translation",
                value: "громкость | том, книга | объём");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4543L,
                column: "translation",
                value: "палата, отделение, камера | округ, район");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4556L,
                column: "translation",
                value: "умыться | помыть посуду");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4557L,
                column: "translation",
                value: "отходы, обрезки, потери и т.п. | тратить (впустую)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4563L,
                column: "translation",
                value: "волна | махать, колебаться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4584L,
                column: "translation",
                value: "пособие, мат. помощь | благополучие");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4606L,
                column: "translation",
                value: "ловкач, умелец (в области) | просвистеть, пронестись");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4636L,
                column: "translation",
                value: "в течение | в пределах, внутри");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4642L,
                column: "translation",
                value: "удивление, удивляться | хотеть знать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4646L,
                column: "translation",
                value: "тренироваться | получиться, сработать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4674L,
                column: "translation",
                value: "пока ещё (отриц.) | всё же");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4675L,
                column: "translation",
                value: "уступать | приносить (доход)");

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "id",
                keyValue: 729L,
                column: "name",
                value: "christmas");

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "id",
                keyValue: 1376L,
                column: "name",
                value: "easter");

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "id",
                keyValue: 1971L,
                column: "name",
                value: "gypsy");

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "id",
                keyValue: 2141L,
                column: "name",
                value: "id");

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "id",
                keyValue: 2298L,
                column: "name",
                value: "jew");

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "id",
                keyValue: 2720L,
                column: "name",
                value: "muslim");

            migrationBuilder.CreateIndex(
                name: "ix_word_group_words_serial_number",
                table: "word_group_words",
                column: "serial_number");

            migrationBuilder.CreateIndex(
                name: "ix_word_group_words_word_group_id",
                table: "word_group_words",
                column: "word_group_id");

            migrationBuilder.CreateIndex(
                name: "ix_word_group_words_word_translation_id",
                table: "word_group_words",
                column: "word_translation_id");

            migrationBuilder.CreateIndex(
                name: "ix_word_translation_states_user_id",
                table: "word_translation_states",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_word_translation_states_word_translation_id",
                table: "word_translation_states",
                column: "word_translation_id");
            
            migrationBuilder.Sql(@"
insert into word_translation_states (learn_state, view_count, learned_at, word_translation_id, user_id)
select learn_state, view_count, learned_at, word_translation_id, user_id
from word_group_word_translations
inner join word_groups wg on wg.id = word_group_word_translations.word_group_id");
            
            migrationBuilder.Sql(@"
insert into word_group_words (serial_number, word_group_id, word_translation_id)
select serial_number, word_group_id, word_translation_id
from word_group_word_translations");
            
            migrationBuilder.DropTable(
                name: "word_group_word_translations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "word_group_words");

            migrationBuilder.DropTable(
                name: "word_translation_states");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "users");

            migrationBuilder.CreateTable(
                name: "word_group_word_translations",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    word_group_id = table.Column<long>(type: "bigint", nullable: false),
                    word_translation_id = table.Column<long>(type: "bigint", nullable: false),
                    learn_state = table.Column<byte>(type: "smallint", nullable: false),
                    learned_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    serial_number = table.Column<long>(type: "bigint", nullable: false),
                    view_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_word_group_word_translations", x => x.id);
                    table.ForeignKey(
                        name: "fk_word_group_word_translations_word_groups_word_group_id",
                        column: x => x.word_group_id,
                        principalTable: "word_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_word_group_word_translations_word_translations_word_transla",
                        column: x => x.word_translation_id,
                        principalTable: "word_translations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "languages",
                keyColumn: "id",
                keyValue: 1L,
                column: "code",
                value: "en");

            migrationBuilder.InsertData(
                table: "languages",
                columns: new[] { "id", "code" },
                values: new object[] { 2L, "ru" });

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 17L,
                column: "translation",
                value: "оскорблять, бранить, брань, злоупотреблять, насилие, домогательство");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 22L,
                column: "translation",
                value: "случайность, происшествие, напр. ДТП");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 29L,
                column: "translation",
                value: "счёт (в банке), отчёт");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 57L,
                column: "translation",
                value: "принимать, перенимать, усыновить или взять (животное)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 72L,
                column: "translation",
                value: "воздушный, антенна");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 73L,
                column: "translation",
                value: "дело, занятие, роман, любовная история");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 84L,
                column: "translation",
                value: "век, эпоха, возраст");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 180L,
                column: "translation",
                value: "появиться, казаться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 183L,
                column: "translation",
                value: "применять, применяться, обращаться (с заявлением)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 189L,
                column: "translation",
                value: "присвоить, подходящий, присущий");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 214L,
                column: "translation",
                value: "статья, вещь, изделие");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 241L,
                column: "translation",
                value: "принимать на себя, предпогалать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 289L,
                column: "translation",
                value: "бакалавр, холостяк");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 295L,
                column: "translation",
                value: "происхождение, предыстория, фон");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 317L,
                column: "translation",
                value: "пластина, брусок, прут и т. д., загораживать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 324L,
                column: "translation",
                value: "кора, лаять");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 334L,
                column: "translation",
                value: "бита, летучая мышь");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 353L,
                column: "translation",
                value: "балка, перекладина, луч");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 355L,
                column: "translation",
                value: "рожать, нести, втч перен.");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 358L,
                column: "translation",
                value: "победить, бить");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 402L,
                column: "translation",
                value: "счёт (к оплате), банкнота");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 421L,
                column: "translation",
                value: "дуновение, порыв, взрыв, взрывать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 434L,
                column: "translation",
                value: "кусок, глыба и т. д., квартал");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 441L,
                column: "translation",
                value: "дуть, удар");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 444L,
                column: "translation",
                value: "взорвать, накачивать, надувать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 449L,
                column: "translation",
                value: "совет, коллегия, доска, борт, подниматься на борт");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 456L,
                column: "translation",
                value: "связь, узы, соединение, обязательство, облигация");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 479L,
                column: "translation",
                value: "всплеск, приступ, бой, поединок");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 480L,
                column: "translation",
                value: "бант, бабочка, лук, поклон, наклоняться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 489L,
                column: "translation",
                value: "ветвь, филиал, ответвление");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 502L,
                column: "translation",
                value: "вспыхнуть, разразиться, сбежать, вырваться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 527L,
                column: "translation",
                value: "поднять тему, воспитывать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 558L,
                column: "translation",
                value: "шишка, выпуклость, удар, ударять");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 576L,
                column: "translation",
                value: "торец, зад, задница");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 615L,
                column: "translation",
                value: "ёмкость, вместимость, способность, возможность");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 624L,
                column: "translation",
                value: "забота, уход, переживать, интересоваться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 637L,
                column: "translation",
                value: "случай, дело, ящик, футляр, чехол");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 640L,
                column: "translation",
                value: "бросать, метать, отливать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 645L,
                column: "translation",
                value: "становиться популярным, внезапно понять");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 686L,
                column: "translation",
                value: "заряжать, нагружать, обвинять, плата");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 699L,
                column: "translation",
                value: "посмотреть, заценить, освободить номер");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 710L,
                column: "translation",
                value: "грудь (грудная клетка), сундук");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 745L,
                column: "translation",
                value: "требовать, претендовать, утверждать, претендовать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 772L,
                column: "translation",
                value: "отсекать, обрезать, зажим, зажимать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 790L,
                column: "translation",
                value: "автобус, вагон, телега, тренер");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 795L,
                column: "translation",
                value: "покрывать, пальто");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 819L,
                column: "translation",
                value: "идти вместе, продвигаться (о работе)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 820L,
                column: "translation",
                value: "найти, заполучить, зайти");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 824L,
                column: "translation",
                value: "выйти, получиться, отвалиться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 826L,
                column: "translation",
                value: "выступить, заявить, выходить (напр. об альбоме)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 829L,
                column: "translation",
                value: "очнуться, доходить до");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 833L,
                column: "translation",
                value: "произойти или появиться, приближаться (о событии)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 845L,
                column: "translation",
                value: "приверженность, обязательство");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 847L,
                column: "translation",
                value: "общий, обычный, распространённый");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 862L,
                column: "translation",
                value: "допонять, дополнение, набор, состав, комплект");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 884L,
                column: "translation",
                value: "состояние, условие");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 887L,
                column: "translation",
                value: "дать, принести, присудить, совещаться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 909L,
                column: "translation",
                value: "рассматривать, учитывать, считать чем-либо");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 973L,
                column: "translation",
                value: "считаться, иметь значение, считать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 975L,
                column: "translation",
                value: "противостоять, противоположный, стойка, прилавок");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 983L,
                column: "translation",
                value: "суд, двор (королевский), игровая площадка");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1055L,
                column: "translation",
                value: "узда, обуздать, сдержать, бордюр или обочина");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1060L,
                column: "translation",
                value: "текущий, актуальный, ток, поток, течение");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1067L,
                column: "translation",
                value: "заказной, индивидуальный, обычай, привычка");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1085L,
                column: "translation",
                value: "тире, чёрточка, бросать, бросаться, разрушить (перен.)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1113L,
                column: "translation",
                value: "отказаться, отклонить, снижаться, снижение");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1132L,
                column: "translation",
                value: "степень (во всех значениях), градус");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1140L,
                column: "translation",
                value: "доставлять, рожать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1142L,
                column: "translation",
                value: "требовать, спрос");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1168L,
                column: "translation",
                value: "пустыня, бросать, оставлять");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1222L,
                column: "translation",
                value: "прямой (обычн. перен.знач.), направлять");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1247L,
                column: "translation",
                value: "тарелка или миска, блюдо");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1252L,
                column: "translation",
                value: "прогонять, посылать, увольнять, отклонить, отбросить");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1262L,
                column: "translation",
                value: "располагать, распоряжаться, избавиться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1296L,
                column: "translation",
                value: "домашний, внутренний (о политике)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1311L,
                column: "translation",
                value: "тяга, сквозняк, проект, черновик, набросок");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1329L,
                column: "translation",
                value: "водить машину, двигать, гнать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1332L,
                column: "translation",
                value: "падать, ронять, капля");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1351L,
                column: "translation",
                value: "немой, тупой");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1353L,
                column: "translation",
                value: "сваливать, сбрасывать свалка, бросать (парня/девушку)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1388L,
                column: "translation",
                value: "либо, тоже (не), любой из двух");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1414L,
                column: "translation",
                value: "использовать, нанимать на работу");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1451L,
                column: "translation",
                value: "давать название, давать право (по заслугам)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1505L,
                column: "translation",
                value: "исполнить, казнить");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1510L,
                column: "translation",
                value: "исчерпывать, истощать, выхлопные газы");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1553L,
                column: "translation",
                value: "сооружение, объект, лёгкость, удобство");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1560L,
                column: "translation",
                value: "слабый, неуловимый, обморок, падать в обморок");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1561L,
                column: "translation",
                value: "светлый, справедливый, честный");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1570L,
                column: "translation",
                value: "вестись, влюбляться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1582L,
                column: "translation",
                value: "необычный, причудливый, модный, представлять, полагать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1588L,
                column: "translation",
                value: "мода, стиль, образ, манер");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1594L,
                column: "translation",
                value: "недостаток, неисправность, вина, ошибка");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1611L,
                column: "translation",
                value: "парень, человек, товарищ по чему-либо");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1641L,
                column: "translation",
                value: "штраф, тонкий, хороший");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1665L,
                column: "translation",
                value: "плоский, ровный, квартира");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1675L,
                column: "translation",
                value: "короткое резкое движение, фильм (разг.)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1678L,
                column: "translation",
                value: "полёт, рейс, бегство");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1687L,
                column: "translation",
                value: "пол, этаж");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1698L,
                column: "translation",
                value: "промывать, смывать, румянец, порозоветь");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1706L,
                column: "translation",
                value: "расстаривать, разрушать, фольга");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1730L,
                column: "translation",
                value: "ковать, подделывать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1733L,
                column: "translation",
                value: "бывший, первый (из названных)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1739L,
                column: "translation",
                value: "состояние (деньги), счастье, удача, судьба");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1741L,
                column: "translation",
                value: "приёмный (ребёнок), способствовать, питать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1795L,
                column: "translation",
                value: "предоставлять, обставлять, меблировать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1860L,
                column: "translation",
                value: "раздавать, дарить, выдать (раскрыть)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1864L,
                column: "translation",
                value: "отказаться, сдаться, бросить (привычку)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1891L,
                column: "translation",
                value: "быть проданным за, выбирать, предпочитать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1893L,
                column: "translation",
                value: "сработать, отключиться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1894L,
                column: "translation",
                value: "происходить, продолжаться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1912L,
                column: "translation",
                value: "оценка, класс, уровень");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1926L,
                column: "translation",
                value: "могила, серьёзный");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1942L,
                column: "translation",
                value: "крошка, песок, гравий, твёрдость, стойкость");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1948L,
                column: "translation",
                value: "валовой, грязный, грубый (во всех смыслах)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1950L,
                column: "translation",
                value: "становиться, расти или выращивать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1963L,
                column: "translation",
                value: "разрыв, пропасть, залив");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1975L,
                column: "translation",
                value: "град, окликнуть, привлечь внимание, приветствовать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 1992L,
                column: "translation",
                value: "рукоятка, управляться, обращаться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2074L,
                column: "translation",
                value: "ударить, удар, попасть, достичь");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2083L,
                column: "translation",
                value: "оставаться на линии, держаться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2094L,
                column: "translation",
                value: "капот, кожух, капюшон");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2097L,
                column: "translation",
                value: "потрахаться, подключить, смонтировать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2108L,
                column: "translation",
                value: "хозяин, быть хозяином, множество");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2128L,
                column: "translation",
                value: "горб, горбиться, догадка, предчуствие");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2137L,
                column: "translation",
                value: "толкаться, торопиться, нечестно добыть (амер.)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2145L,
                column: "translation",
                value: "больной, дурной, нехороший");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2242L,
                column: "translation",
                value: "честность, порядочность, целостность");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2268L,
                column: "translation",
                value: "представить, познакомить, ввести (в употребление)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2277L,
                column: "translation",
                value: "вовлекать, увлекать, содержать в себе (процесс)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2279L,
                column: "translation",
                value: "утюг, гладить, железо, железный");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2282L,
                column: "translation",
                value: "издать, выпустить, выпуск, вопрос, проблема");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2296L,
                column: "translation",
                value: "дёргать, резкое движение, придурок");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2297L,
                column: "translation",
                value: "струя, реактивный двигатель/самолёт");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2303L,
                column: "translation",
                value: "сустав, шарнир, стык и т. д., совместный, объединённый");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2336L,
                column: "translation",
                value: "шутить, разыгрывать, ребёнок");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2340L,
                column: "translation",
                value: "добрый, тип, вид");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2375L,
                column: "translation",
                value: "упущение, оплошность, промежуток времени");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2382L,
                column: "translation",
                value: "поздний, покойный");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2458L,
                column: "translation",
                value: "строка, линия, ряд");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2461L,
                column: "translation",
                value: "бельё, льняная ткань");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2492L,
                column: "translation",
                value: "домик, поселиться, остановиться, подавать (документ)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2518L,
                column: "translation",
                value: "гостиная, холл, комната отдыха, расслабляться, бездельничать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2552L,
                column: "translation",
                value: "разобрать, понять, целоваться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2554L,
                column: "translation",
                value: "выдумать, помириться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2567L,
                column: "translation",
                value: "руководство, учебник, ручной");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2573L,
                column: "translation",
                value: "край, граница, маржа, накрутка");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2586L,
                column: "translation",
                value: "хозяин, овладеть (напр. искусством)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2589L,
                column: "translation",
                value: "соответствие, нечто соответствующее, спичка");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2592L,
                column: "translation",
                value: "вещество, материя, дело, вопрос, иметь значение");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2601L,
                column: "translation",
                value: "иметь в виду, означать, предназначать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2605L,
                column: "translation",
                value: "мера, мероприятие, измерять, измерение");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2652L,
                column: "translation",
                value: "мина, шахта, рудник");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2654L,
                column: "translation",
                value: "второстепенный, незначительный, несовершеннолетний");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2659L,
                column: "translation",
                value: "нищета, несчастье, страдание");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2660L,
                column: "translation",
                value: "скучать, пропускать, упустить");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2666L,
                column: "translation",
                value: "госпожа, хозяйка, любовница");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2678L,
                column: "translation",
                value: "плесень, форма, формировать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2679L,
                column: "translation",
                value: "крот, родинка");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2699L,
                column: "translation",
                value: "монтировать, устанавливать, подниматься, забираться, гора");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2729L,
                column: "translation",
                value: "гвоздь, прибивать, ноготь");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2738L,
                column: "translation",
                value: "родной, местный, туземный");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2753L,
                column: "translation",
                value: "ни один из двух, тоже не");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2842L,
                column: "translation",
                value: "масло, нефть");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2867L,
                column: "translation",
                value: "порядок, упорядочивать, заказ, заказывать, приказ");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2895L,
                column: "translation",
                value: "выдающийся, неоплаченный, нерешённый");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2918L,
                column: "translation",
                value: "задолжать, быть обязанным чем-л.");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2924L,
                column: "translation",
                value: "пачка, связка, колода, и т. д., упаковывать, собирать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2925L,
                column: "translation",
                value: "подушечка пальца, лапы, блокнот, панель, клавиатура");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2946L,
                column: "translation",
                value: "роль, часть, разделять(ся)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2963L,
                column: "translation",
                value: "мимо, прошлый, прошедший");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 2999L,
                column: "translation",
                value: "ровня, ровесник, вглядываться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3023L,
                column: "translation",
                value: "сохраниться, упорствовать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3038L,
                column: "translation",
                value: "прибрать, подобрать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3054L,
                column: "translation",
                value: "трубка, труба");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3059L,
                column: "translation",
                value: "подавать (мяч), ставить (напр. палатку)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3065L,
                column: "translation",
                value: "ясный, очевидный, ровный, равнина, простой, незамысловатый");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3068L,
                column: "translation",
                value: "растение, сажать, завод, производство");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3077L,
                column: "translation",
                value: "залог, оставлять в залог, обещание, обязательство");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3080L,
                column: "translation",
                value: "план, чертёж, сюжет");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3091L,
                column: "translation",
                value: "смысл, суть, точка, очко, острие, кончик, пункт");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3097L,
                column: "translation",
                value: "полюс, шест, столб");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3125L,
                column: "translation",
                value: "фунт, долбить, толочь");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3156L,
                column: "translation",
                value: "настоящее (время), присутствующий, в наличии");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3163L,
                column: "translation",
                value: "довольно-таки, приятный");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3182L,
                column: "translation",
                value: "исследовать, проверить, датчик, зонд");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3198L,
                column: "translation",
                value: "побуждать, подстрекать, быстрый, оперативный");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3210L,
                column: "translation",
                value: "вести, осуществлять, преследовать (законодательно)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3248L,
                column: "translation",
                value: "отвратить, отвлечь и т. д., откладывать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3249L,
                column: "translation",
                value: "надеть, провести (мероприятие)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3250L,
                column: "translation",
                value: "потушить, обременять, стеснять");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3277L,
                column: "translation",
                value: "раса, гонка");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3287L,
                column: "translation",
                value: "растить (детей), поднять, повысить");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3290L,
                column: "translation",
                value: "собраться, созвать (напр. армию), оживать, приходить в себя");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3303L,
                column: "translation",
                value: "курс, тариф, ставка, показатель, уровень");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3321L,
                column: "translation",
                value: "разум, благоразумие, причина, мотив");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3326L,
                column: "translation",
                value: "квитанция, получение");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3330L,
                column: "translation",
                value: "перерыв, выемка, впадина");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3365L,
                column: "translation",
                value: "внимание, уважение, считать, рассматривать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3377L,
                column: "translation",
                value: "родственник, относительный");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3398L,
                column: "translation",
                value: "делать, придавать свойство, воздавать, оказывать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3420L,
                column: "translation",
                value: "запас, запасной, запасать, бронировать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3428L,
                column: "translation",
                value: "решиться, решимость, разрешить (ситуацию)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3435L,
                column: "translation",
                value: "остаток, остальное, отдых, отдыхать, покоиться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3502L,
                column: "translation",
                value: "камень, скала, качать, трясти");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3506L,
                column: "translation",
                value: "рулон, клубок, свиток и т. д., катиться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3515L,
                column: "translation",
                value: "сменять, чередовать, вращать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3523L,
                column: "translation",
                value: "грести, ряд");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3534L,
                column: "translation",
                value: "правило, править");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3587L,
                column: "translation",
                value: "чешуя, шелуха, взбираться, масштаб, шкала");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3611L,
                column: "translation",
                value: "драка, схватка, карабкаться, продираться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3621L,
                column: "translation",
                value: "винт, ввинчивать, к чёрту");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3627L,
                column: "translation",
                value: "печать, запечатывать, тюлень");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3653L,
                column: "translation",
                value: "чувство, осознание, смысл, значение");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3656L,
                column: "translation",
                value: "предложение, приговор");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3663L,
                column: "translation",
                value: "служить, сидеть (в тюрьме), подавать (блюдо)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3670L,
                column: "translation",
                value: "задержать, обойтись в (сумму)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3672L,
                column: "translation",
                value: "устроить, организовать, познакомить, свести");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3673L,
                column: "translation",
                value: "уладить, селиться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3685L,
                column: "translation",
                value: "тень, оттенок (яркости)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3687L,
                column: "translation",
                value: "вал, ось, стержень, шахта (напр. лифта)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3688L,
                column: "translation",
                value: "трясти, пожать (руки)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3694L,
                column: "translation",
                value: "делить, доля, разделять (напр. мнение)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3703L,
                column: "translation",
                value: "явный, полный, чистый, отвесный");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3710L,
                column: "translation",
                value: "сменить, сдвинуть, смена (на работе)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3717L,
                column: "translation",
                value: "стрелять, снимать, фотографировать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3753L,
                column: "translation",
                value: "вид, поле зрения, достопримечаетльность");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3754L,
                column: "translation",
                value: "знак, подпись, подписывать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3769L,
                column: "translation",
                value: "поскольку, с (какого-то времени)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3871L,
                column: "translation",
                value: "единственный, подошва");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3873L,
                column: "translation",
                value: "сплошной, твёрдый, крепкий");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3876L,
                column: "translation",
                value: "решение, ответ, раствор");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3892L,
                column: "translation",
                value: "пространство, космос");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3895L,
                column: "translation",
                value: "щадить, избавить, запасной, лишний, выделить, уделить");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3913L,
                column: "translation",
                value: "заклинание, чары, произносить (писать) по буквам");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3932L,
                column: "translation",
                value: "место, пятно, заметить, увидеть");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3937L,
                column: "translation",
                value: "прыгать, источник, проистекать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3943L,
                column: "translation",
                value: "квадрат, квадратный, площадь");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3958L,
                column: "translation",
                value: "сцена, стадия, ступень");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3962L,
                column: "translation",
                value: "стойка, кол, столб, ставка, делать ставку");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3964L,
                column: "translation",
                value: "красться, преследовать, стебель");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3965L,
                column: "translation",
                value: "задержаться, застопориться, палатка, ларёк");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3971L,
                column: "translation",
                value: "выступать за, обозначать (в сокращении)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3981L,
                column: "translation",
                value: "государство, состояние, заявить, отметить");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 3984L,
                column: "translation",
                value: "оставаться, остановиться пожить");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4014L,
                column: "translation",
                value: "запас, акции");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4020L,
                column: "translation",
                value: "крыльцо со ступеньками (амер.), наклоняться или сутулиться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4022L,
                column: "translation",
                value: "хранить, хранилище, магазин");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4029L,
                column: "translation",
                value: "застрять, сесть на мель, прядь, нить (об. скрученная)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4048L,
                column: "translation",
                value: "полоса, лента, снимать (обнажать)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4065L,
                column: "translation",
                value: "предмет, тема, подверженный, подвергать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4099L,
                column: "translation",
                value: "костюм, комплект, подходить, соответствовать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4115L,
                column: "translation",
                value: "поставлять, поставка, предложение");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4144L,
                column: "translation",
                value: "клясться, ругаться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4162L,
                column: "translation",
                value: "канцелярская кнопка, гвоздик, курс, линия поведения");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4163L,
                column: "translation",
                value: "принадлежности, снаряжение, взяться за что-л.");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4179L,
                column: "translation",
                value: "снять, взлететь");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4180L,
                column: "translation",
                value: "соревноваться, столкнуться, набрать (напр. рабочих)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4195L,
                column: "translation",
                value: "стучать, кран");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4216L,
                column: "translation",
                value: "храм, висок");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4220L,
                column: "translation",
                value: "иметь склонность, ухаживать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4225L,
                column: "translation",
                value: "срок, период, термин");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4228L,
                column: "translation",
                value: "отношения, условия, соглашение");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4246L,
                column: "translation",
                value: "толстый, густой");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4275L,
                column: "translation",
                value: "галочка, поставить галочку, клещ");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4280L,
                column: "translation",
                value: "галстук, завязка и т.п., связывать, завязывать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4294L,
                column: "translation",
                value: "кончик, верхушка, совет, рекомендация");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4299L,
                column: "translation",
                value: "ткань, бумажная салфетка");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4319L,
                column: "translation",
                value: "связь, контакт, касаться, прикосновение");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4334L,
                column: "translation",
                value: "поезд, тренировать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4358L,
                column: "translation",
                value: "испытание, пробный, судебный процесс");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4376L,
                column: "translation",
                value: "багажник, ствол дерева, чемодан, сундук");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4381L,
                column: "translation",
                value: "тюбик, труба, метро (в Лондоне)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4388L,
                column: "translation",
                value: "мелодия, мотив, настраивать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4395L,
                column: "translation",
                value: "выключить, свернуть (с дороги)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4396L,
                column: "translation",
                value: "включить, заводить, возбуждать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4440L,
                column: "translation",
                value: "вертикальный, стоячий, честный");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4454L,
                column: "translation",
                value: "полный, абсолютный, издать, произнести");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4457L,
                column: "translation",
                value: "тщеславный, самолюбивый, напрасный, безрезультатный");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4471L,
                column: "translation",
                value: "свод, небосвод, хранилище, об. в подвале");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4485L,
                column: "translation",
                value: "обочина, грань, предел");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4489L,
                column: "translation",
                value: "сосуд, судно");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4521L,
                column: "translation",
                value: "громкость, том, книга, объём");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4543L,
                column: "translation",
                value: "палата, отделение, камера, округ, район");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4556L,
                column: "translation",
                value: "умыться, помыть посуду");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4557L,
                column: "translation",
                value: "отходы, обрезки, потери и т.п., тратить (впустую)");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4563L,
                column: "translation",
                value: "волна, махать, колебаться");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4584L,
                column: "translation",
                value: "пособие, мат. помощь, благополучие");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4606L,
                column: "translation",
                value: "ловкач, умелец (в области), просвистеть, пронестись");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4636L,
                column: "translation",
                value: "в течение, в пределах, внутри");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4642L,
                column: "translation",
                value: "удивление, удивляться, хотеть знать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4646L,
                column: "translation",
                value: "тренироваться, получиться, сработать");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4674L,
                column: "translation",
                value: "пока ещё (отриц.), всё же");

            migrationBuilder.UpdateData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4675L,
                column: "translation",
                value: "уступать, приносить (доход)");

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "id",
                keyValue: 729L,
                column: "name",
                value: "Christmas");

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "id",
                keyValue: 1376L,
                column: "name",
                value: "Easter");

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "id",
                keyValue: 1971L,
                column: "name",
                value: "Gypsy");

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "id",
                keyValue: 2141L,
                column: "name",
                value: "ID");

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "id",
                keyValue: 2298L,
                column: "name",
                value: "Jew");

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "id",
                keyValue: 2720L,
                column: "name",
                value: "Muslim");

            migrationBuilder.CreateIndex(
                name: "ix_word_group_word_translations_learn_state",
                table: "word_group_word_translations",
                column: "learn_state");

            migrationBuilder.CreateIndex(
                name: "ix_word_group_word_translations_serial_number",
                table: "word_group_word_translations",
                column: "serial_number");

            migrationBuilder.CreateIndex(
                name: "ix_word_group_word_translations_word_group_id",
                table: "word_group_word_translations",
                column: "word_group_id");

            migrationBuilder.CreateIndex(
                name: "ix_word_group_word_translations_word_translation_id",
                table: "word_group_word_translations",
                column: "word_translation_id");
        }
    }
}
