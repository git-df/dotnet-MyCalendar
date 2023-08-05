using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyCalendar.Migrations
{
    /// <inheritdoc />
    public partial class DummyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedDate", "Password", "Salt" },
                values: new object[,]
                {
                    { new Guid("0b120695-5261-4a24-89a1-a050944dc4f4"), "SYSTEM", null, "akwiatkowska@mc.pl", "Agnieszka", "Kwiatkowska", null, null, "C4612FFC6A0C63EF92B85E6B3CC3230265D0CA0C7828589FC59805B0ACF71E73", "314AE5558CE35ADED929DA1DE17FCE0E16B5F993ECE3EAE552C696F4191E376F" },
                    { new Guid("3715e326-6e29-43d7-bb77-af4440508186"), "SYSTEM", null, "nmazur@mc.pl", "Nikola", "Mazur", null, null, "EF44C1BAE114AECB845C356DCBC23AA510518214487BE43CECD658F100CF4FA4", "315419C3F8AB3B7C21A55D9E573DC0F7B40CCF0174CB8874CDC40CF78F7F7E9D" },
                    { new Guid("65dd2018-1cc6-4d0d-8f24-65909cd5d910"), "SYSTEM", null, "dmroz@mc.pl", "Damian", "Mróz", null, null, "FF29A011E1FE2EE6F15FB178E31A371EB131FE8C0676D3AAB01A8A787461DBFE", "2CE264DB7526229035E484B9FCEA4D4F538DE3BB171B4666255302EF7694C278" },
                    { new Guid("9ce89f11-4d8b-4d78-98ee-4ef4640dfadf"), "SYSTEM", null, "cjasinski@mc.pl", "Cyprian", "Jasiński", null, null, "D22D6E8BCCCD20674DC25D98AA2DAEDCE9BD1D88F7ED6BA16DFFCBB9F0944606", "B3F4EF86908A730D7243DF0752A1A3A405B1BDDC8B2AE54CEA1F16550F433576" },
                    { new Guid("9d11283a-ac17-4201-ba97-0f6417ebc4ee"), "SYSTEM", null, "jsobczak@mc.pl", "Jan", "Sobczak", null, null, "0DAA04E484113634CB9054FD667DCAFFCFCBFB7D05B1D7EB2274622C338BD67E", "7A0418874FC3F25E48B539AEE4F4BD4B163E2A273AA87C83C1A91336C7B7AE7E" },
                    { new Guid("acb3fd62-e723-44c5-835a-39c26cd218c3"), "SYSTEM", null, "achmielewska@mc.pl", "Anita", "Chmielewska", null, null, "DD19A6E45F6BB9B22D3E66D68D6AB0BEDF54E2CDA8A9BD206F7EED6C24E26150", "72A68FA7BB8B5CFEFC9F4BF2977ABAC289620344E177215D8ABFA1DC7C54C395" },
                    { new Guid("b9bfab9e-fa7c-447f-a1c5-658f8b748bd0"), "SYSTEM", null, "nzalewska@mc.pl", "Natasza", "Zalewska", null, null, "2FAACE1191BDA8CD9DBAF7C1A4639D7185E1FB50D538C4D30957A55BABF54EFA", "83611AD28ABB837E17C9A86C64091D9BA8AF5162857FB867A711C3E160C033CA" },
                    { new Guid("beed33b1-14a4-4497-a4d4-46192fcd50be"), "SYSTEM", null, "ncieslak@mc.pl", "Norbert", "Cieślak", null, null, "E1CA4FC7831AB4E343CE99220E72F643E2432D38AD57A19B0B0E23E6EB5A5401", "E27042C08FB0BC95650E8E9823B00A799B5D21C96D3E9ACC6CB5D21F17DACB85" },
                    { new Guid("e20e44a0-27e3-4a95-9217-a898f54902c3"), "SYSTEM", null, "agorski@mc.pl", "Antoni", "Górski", null, null, "26D6B907FCB666520B0D76AE5131DCB7DCD94E7ADE749AFB052BA15AEC206B76", "69258D4399C02EC75555ACF24CC164AAFFEC0CB569977D5F0E11CA69C0BDD7AD" },
                    { new Guid("fb8e707d-9a9d-40f6-9819-968add26204e"), "SYSTEM", null, "hadamski@mc.pl", "Henryk", "Adamski", null, null, "631502BC927D8265FAACD1D32299BBCA705BEBF1FD79250E054F77398F5C6B54", "49DF6A0F9C34A50A9178470E0CE3E1EB841C5F3BEEE2C18B36E77F702CC57A2A" }
                });

            migrationBuilder.InsertData(
                table: "AccesRequests",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "FromUserId", "IsAccepted", "ModifiedBy", "ModifiedDate", "ToUserId" },
                values: new object[,]
                {
                    { 1, "SYSTEM", null, new Guid("3715e326-6e29-43d7-bb77-af4440508186"), true, null, null, new Guid("fb8e707d-9a9d-40f6-9819-968add26204e") },
                    { 2, "SYSTEM", null, new Guid("0b120695-5261-4a24-89a1-a050944dc4f4"), true, null, null, new Guid("fb8e707d-9a9d-40f6-9819-968add26204e") },
                    { 3, "SYSTEM", null, new Guid("e20e44a0-27e3-4a95-9217-a898f54902c3"), false, null, null, new Guid("fb8e707d-9a9d-40f6-9819-968add26204e") },
                    { 4, "SYSTEM", null, new Guid("65dd2018-1cc6-4d0d-8f24-65909cd5d910"), false, null, null, new Guid("fb8e707d-9a9d-40f6-9819-968add26204e") },
                    { 5, "SYSTEM", null, new Guid("b9bfab9e-fa7c-447f-a1c5-658f8b748bd0"), true, null, null, new Guid("9ce89f11-4d8b-4d78-98ee-4ef4640dfadf") },
                    { 6, "SYSTEM", null, new Guid("acb3fd62-e723-44c5-835a-39c26cd218c3"), true, null, null, new Guid("9ce89f11-4d8b-4d78-98ee-4ef4640dfadf") },
                    { 7, "SYSTEM", null, new Guid("beed33b1-14a4-4497-a4d4-46192fcd50be"), false, null, null, new Guid("9ce89f11-4d8b-4d78-98ee-4ef4640dfadf") },
                    { 8, "SYSTEM", null, new Guid("9d11283a-ac17-4201-ba97-0f6417ebc4ee"), false, null, null, new Guid("9ce89f11-4d8b-4d78-98ee-4ef4640dfadf") }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "EventDate", "Label", "ModifiedBy", "ModifiedDate", "MonyhlyEvent", "Title", "UserId", "YearlyEvent" },
                values: new object[,]
                {
                    { 1, "SYSTEM", null, "Wielkie święto", new DateTime(2000, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Urodziny", null, null, false, "Moje urodziny", new Guid("fb8e707d-9a9d-40f6-9819-968add26204e"), true },
                    { 2, "SYSTEM", null, "Wyjazd do Włoch", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wycieczka", null, null, false, "Wakacje", new Guid("fb8e707d-9a9d-40f6-9819-968add26204e"), false },
                    { 3, "SYSTEM", null, "Nie zapomnij wziąść wolne w pracy", new DateTime(2000, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Urodziny", null, null, false, "Urodziny Adama", new Guid("fb8e707d-9a9d-40f6-9819-968add26204e"), true },
                    { 4, "SYSTEM", null, "Nie zapomnij zapłacić", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rachunki", null, null, true, "Rachunek za prąd", new Guid("9ce89f11-4d8b-4d78-98ee-4ef4640dfadf"), true },
                    { 5, "SYSTEM", null, "Termin do końca miesiąca", new DateTime(2000, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rachunki", null, null, true, "Rachunek za wodę", new Guid("9ce89f11-4d8b-4d78-98ee-4ef4640dfadf"), true },
                    { 6, "SYSTEM", null, "Koncert w Warszawie", new DateTime(2025, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rozrywka", null, null, false, "Koncert", new Guid("9ce89f11-4d8b-4d78-98ee-4ef4640dfadf"), false }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "EventId", "Message", "ModifiedBy", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { 1, "SYSTEM", null, 1, "Na pewno wpadnę", null, null, new Guid("3715e326-6e29-43d7-bb77-af4440508186") },
                    { 2, "SYSTEM", null, 1, "Mam już prezent", null, null, new Guid("0b120695-5261-4a24-89a1-a050944dc4f4") },
                    { 3, "SYSTEM", null, 6, "Mogę kierować", null, null, new Guid("b9bfab9e-fa7c-447f-a1c5-658f8b748bd0") },
                    { 4, "SYSTEM", null, 6, "O której jedziemy?", null, null, new Guid("acb3fd62-e723-44c5-835a-39c26cd218c3") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccesRequests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AccesRequests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AccesRequests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AccesRequests",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AccesRequests",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AccesRequests",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AccesRequests",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AccesRequests",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b120695-5261-4a24-89a1-a050944dc4f4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3715e326-6e29-43d7-bb77-af4440508186"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("65dd2018-1cc6-4d0d-8f24-65909cd5d910"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9d11283a-ac17-4201-ba97-0f6417ebc4ee"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("acb3fd62-e723-44c5-835a-39c26cd218c3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b9bfab9e-fa7c-447f-a1c5-658f8b748bd0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("beed33b1-14a4-4497-a4d4-46192fcd50be"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e20e44a0-27e3-4a95-9217-a898f54902c3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9ce89f11-4d8b-4d78-98ee-4ef4640dfadf"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fb8e707d-9a9d-40f6-9819-968add26204e"));
        }
    }
}
