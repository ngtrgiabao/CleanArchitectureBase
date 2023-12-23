using Core.Models.Location;

namespace Core.Constant
{
    public class AddressUtil
    {
        public static List<ProvinceModel> GetProvinceModels()
        {
            List<ProvinceModel> provinces = new List<ProvinceModel>
            {
                new ProvinceModel { Id = 1, Title = "Thành phố Hồ Chí Minh" },
                new ProvinceModel { Id = 2, Title = "Hà Nội" },
                new ProvinceModel { Id = 3, Title = "Đà Nẵng" },
                new ProvinceModel { Id = 4, Title = "Hải Phòng" },
                new ProvinceModel { Id = 5, Title = "Cần Thơ" },
                new ProvinceModel { Id = 6, Title = "An Giang" },
                new ProvinceModel { Id = 7, Title = "Bà Rịa - Vũng Tàu" },
                new ProvinceModel { Id = 8, Title = "Bạc Liêu" },
                new ProvinceModel { Id = 9, Title = "Bắc Giang" },
                new ProvinceModel { Id = 10, Title = "Bắc Kạn" },
                new ProvinceModel { Id = 11, Title = "Bắc Ninh" },
                new ProvinceModel { Id = 12, Title = "Bến Tre" },
                new ProvinceModel { Id = 13, Title = "Bình Định" },
                new ProvinceModel { Id = 14, Title = "Bình Dương" },
                new ProvinceModel { Id = 15, Title = "Bình Phước" },
                new ProvinceModel { Id = 16, Title = "Bình Thuận" },
                new ProvinceModel { Id = 17, Title = "Cà Mau" },
                new ProvinceModel { Id = 18, Title = "Cao Bằng" },
                new ProvinceModel { Id = 19, Title = "Đắk Lắk" },
                new ProvinceModel { Id = 20, Title = "Đắk Nông" },
                new ProvinceModel { Id = 21, Title = "Điện Biên" },
                new ProvinceModel { Id = 22, Title = "Đồng Nai" },
                new ProvinceModel { Id = 23, Title = "Đồng Tháp" },
                new ProvinceModel { Id = 24, Title = "Gia Lai" },
                new ProvinceModel { Id = 25, Title = "Hà Giang" },
                new ProvinceModel { Id = 26, Title = "Hà Nam" },
                new ProvinceModel { Id = 27, Title = "Hà Tĩnh" },
                new ProvinceModel { Id = 28, Title = "Hải Dương" },
                new ProvinceModel { Id = 29, Title = "Hậu Giang" },
                new ProvinceModel { Id = 30, Title = "Hòa Bình" },
                new ProvinceModel { Id = 31, Title = "Hưng Yên" },
                new ProvinceModel { Id = 32, Title = "Khánh Hòa" },
                new ProvinceModel { Id = 33, Title = "Kiên Giang" },
                new ProvinceModel { Id = 34, Title = "Kon Tum" },
                new ProvinceModel { Id = 35, Title = "Lai Châu" },
                new ProvinceModel { Id = 36, Title = "Lâm Đồng" },
                new ProvinceModel { Id = 37, Title = "Lạng Sơn" },
                new ProvinceModel { Id = 38, Title = "Lào Cai" },
                new ProvinceModel { Id = 39, Title = "Long An" },
                new ProvinceModel { Id = 40, Title = "Nam Định" },
                new ProvinceModel { Id = 41, Title = "Nghệ An" },
                new ProvinceModel { Id = 42, Title = "Ninh Bình" },
                new ProvinceModel { Id = 43, Title = "Ninh Thuận" },
                new ProvinceModel { Id = 44, Title = "Phú Thọ" },
                new ProvinceModel { Id = 45, Title = "Phú Yên" },
                new ProvinceModel { Id = 46, Title = "Quảng Bình" },
                new ProvinceModel { Id = 47, Title = "Quảng Nam" },
                new ProvinceModel { Id = 48, Title = "Quảng Ngãi" },
                new ProvinceModel { Id = 49, Title = "Quảng Ninh" },
                new ProvinceModel { Id = 50, Title = "Quảng Trị" },
                new ProvinceModel { Id = 51, Title = "Sóc Trăng" },
                new ProvinceModel { Id = 52, Title = "Sơn La" },
                new ProvinceModel { Id = 53, Title = "Tây Ninh" },
                new ProvinceModel { Id = 54, Title = "Thái Bình" },
                new ProvinceModel { Id = 55, Title = "Thái Nguyên" },
                new ProvinceModel { Id = 56, Title = "Thanh Hóa" },
                new ProvinceModel { Id = 57, Title = "Thừa Thiên Huế" },
                new ProvinceModel { Id = 58, Title = "Tiền Giang" },
                new ProvinceModel { Id = 59, Title = "Trà Vinh" },
                new ProvinceModel { Id = 60, Title = "Tuyên Quang" },
                new ProvinceModel { Id = 61, Title = "Vĩnh Long" },
                new ProvinceModel { Id = 62, Title = "Vĩnh Phúc" },
                new ProvinceModel { Id = 63, Title = "Yên Bái" }
            };
            return provinces;
        }

        public static List<DistrictModel> GetDistrictModels()
        {
            List<DistrictModel> districts = new List<DistrictModel>
            {
             // TP.Hồ Chí Minh
               new DistrictModel { Id = 101, Title = "Quận 1", ProvinceId = 1 },
               new DistrictModel { Id = 102, Title = "Quận 2", ProvinceId = 1 },
               new DistrictModel { Id = 103, Title = "Quận 3", ProvinceId = 1 },
               new DistrictModel { Id = 104, Title = "Quận 4", ProvinceId = 1 },
               new DistrictModel { Id = 105, Title = "Quận 5", ProvinceId = 1 },
               new DistrictModel { Id = 106, Title = "Quận 6", ProvinceId = 1 },
               new DistrictModel { Id = 107, Title = "Quận 7", ProvinceId = 1 },
               new DistrictModel { Id = 108, Title = "Quận 8", ProvinceId = 1 },
               new DistrictModel { Id = 109, Title = "Quận 9", ProvinceId = 1 },
               new DistrictModel { Id = 110, Title = "Quận 10", ProvinceId = 1 },
                // Thêm các quận khác của TP.Hồ Chí Minh

                // Hà Nội
               new DistrictModel{ Id = 201, Title = "Quận Hoàn Kiếm", ProvinceId = 2 },
               new DistrictModel { Id = 202, Title = "Quận Ba Đình", ProvinceId = 2 },
               new DistrictModel { Id = 203, Title = "Quận Hai Bà Trưng", ProvinceId = 2 },
               new DistrictModel { Id = 204, Title = "Quận Đống Đa", ProvinceId = 2 },
               new DistrictModel { Id = 205, Title = "Quận Tây Hồ", ProvinceId = 2 },
               new DistrictModel { Id = 206, Title = "Quận Cầu Giấy", ProvinceId = 2 },
               new DistrictModel { Id = 207, Title = "Quận Thanh Xuân", ProvinceId = 2 },
                // Thêm các quận khác của Hà Nội

                // Đà Nẵng
               new DistrictModel { Id = 301, Title = "Quận Hải Châu", ProvinceId = 3 },
               new DistrictModel { Id = 302, Title = "Quận Thanh Khê", ProvinceId = 3 },
               new DistrictModel { Id = 303, Title = "Quận Sơn Trà", ProvinceId = 3 },
               new DistrictModel { Id = 304, Title = "Quận Ngũ Hành Sơn", ProvinceId = 3 },
               new DistrictModel { Id = 305, Title = "Quận Liên Chiểu", ProvinceId = 3 },
                // Thêm các quận khác của Đà Nẵng

                // Hải Phòng
               new DistrictModel { Id = 401, Title = "Quận Hồng Bàng", ProvinceId = 4 },
               new DistrictModel { Id = 402, Title = "Quận Ngô Quyền", ProvinceId = 4 },
               new DistrictModel { Id = 403, Title = "Quận Lê Chân", ProvinceId = 4 },
               new DistrictModel { Id = 404, Title = "Quận Hải An", ProvinceId = 4 },
               new DistrictModel { Id = 405, Title = "Quận Kiến An", ProvinceId = 4 },
                // Thêm các quận khác của Hải Phòng

                // Cần Thơ
               new DistrictModel { Id = 501, Title = "Quận Ninh Kiều", ProvinceId = 5 },
               new DistrictModel { Id = 502, Title = "Quận Cái Răng", ProvinceId = 5 },
               new DistrictModel { Id = 503, Title = "Quận Bình Thủy", ProvinceId = 5 },
               new DistrictModel { Id = 504, Title = "Quận Ô Môn", ProvinceId = 5 },
                // Thêm các quận khác của Cần Thơ

                // An Giang
               new DistrictModel { Id = 601, Title = "Huyện Châu Thành", ProvinceId = 6 },
               new DistrictModel { Id = 602, Title = "Huyện Châu Phú", ProvinceId = 6 },
               new DistrictModel { Id = 603, Title = "Huyện Châu Đốc", ProvinceId = 6 },
               new DistrictModel { Id = 604, Title = "Huyện Tịnh Biên", ProvinceId = 6 },
                // Thêm các huyện khác của An Giang

                // Bà Rịa - Vũng Tàu
               new DistrictModel { Id = 701, Title = "Huyện Bà Rịa", ProvinceId = 7 },
               new DistrictModel { Id = 702, Title = "Huyện Vũng Tàu", ProvinceId = 7 },
               new DistrictModel { Id = 703, Title = "Huyện Long Điền", ProvinceId = 7 },
               new DistrictModel { Id = 704, Title = "Huyện Châu Đức", ProvinceId = 7 },
                // Thêm các huyện khác của Bà Rịa - Vũng Tàu

                // Bạc Liêu
               new DistrictModel { Id = 801, Title = "Huyện Hồng Dân", ProvinceId = 8 },
               new DistrictModel { Id = 802, Title = "Huyện Vĩnh Lợi", ProvinceId = 8 },
               new DistrictModel { Id = 803, Title = "Huyện Giá Rai", ProvinceId = 8 },
               new DistrictModel { Id = 804, Title = "Huyện Đông Hải", ProvinceId = 8 },
                // Thêm các huyện khác của Bạc Liêu

                // Bắc Giang
               new DistrictModel { Id = 901, Title = "Huyện Bắc Giang", ProvinceId = 9 },
               new DistrictModel { Id = 902, Title = "Huyện Yên Thế", ProvinceId = 9 },
               new DistrictModel { Id = 903, Title = "Huyện Lục Ngạn", ProvinceId = 9 },
               new DistrictModel { Id = 904, Title = "Huyện Sơn Động", ProvinceId = 9 },
                // Thêm các huyện khác 
                 // Bắc Kạn
               new DistrictModel { Id = 1001, Title = "Huyện Bắc Kạn", ProvinceId = 10 },
               new DistrictModel { Id = 1002, Title = "Huyện Pác Nặm", ProvinceId = 10 },
               new DistrictModel { Id = 1003, Title = "Huyện Ba Bể", ProvinceId = 10 },
               new DistrictModel { Id = 1004, Title = "Huyện Ngân Sơn", ProvinceId = 10 },
                // Thêm các huyện khác của Bắc Kạn

                // Bắc Ninh
               new DistrictModel { Id = 1101, Title = "Huyện Bắc Ninh", ProvinceId = 11 },
               new DistrictModel { Id = 1102, Title = "Huyện Yên Phong", ProvinceId = 11 },
               new DistrictModel { Id = 1103, Title = "Huyện Tiên Du", ProvinceId = 11 },
               new DistrictModel { Id = 1104, Title = "Huyện Thuận Thành", ProvinceId = 11 },
                // Thêm các huyện khác của Bắc Ninh

                // Bến Tre
               new DistrictModel { Id = 1201, Title = "Huyện Châu Thành", ProvinceId = 12 },
               new DistrictModel { Id = 1202, Title = "Huyện Bình Đại", ProvinceId = 12 },
               new DistrictModel { Id = 1203, Title = "Huyện Ba Tri", ProvinceId = 12 },
               new DistrictModel { Id = 1204, Title = "Huyện Thạnh Phú", ProvinceId = 12 },
                // Thêm các huyện khác của Bến Tre

                // Bình Định
               new DistrictModel { Id = 1301, Title = "Huyện Quy Nhơn", ProvinceId = 13 },
               new DistrictModel { Id = 1302, Title = "Huyện An Lão", ProvinceId = 13 },
               new DistrictModel { Id = 1303, Title = "Huyện Hoài Nhơn", ProvinceId = 13 },
               new DistrictModel { Id = 1304, Title = "Huyện Phù Mỹ", ProvinceId = 13 },
                // Thêm các huyện khác của Bình Định

                // Bình Dương
               new DistrictModel { Id = 1401, Title = "Huyện Thủ Dầu Một", ProvinceId = 14 },
               new DistrictModel { Id = 1402, Title = "Huyện Bàu Bàng", ProvinceId = 14 },
               new DistrictModel { Id = 1403, Title = "Huyện Bến Cát", ProvinceId = 14 },
               new DistrictModel { Id = 1404, Title = "Huyện Dầu Tiếng", ProvinceId = 14 },
                // Thêm các huyện khác của Bình Dương

                // Bình Phước
               new DistrictModel { Id = 1501, Title = "Huyện Đồng Xoài", ProvinceId = 15 },
               new DistrictModel { Id = 1502, Title = "Huyện Bù Gia Mập", ProvinceId = 15 },
               new DistrictModel { Id = 1503, Title = "Huyện Chơn Thành", ProvinceId = 15 },
               new DistrictModel { Id = 1504, Title = "Huyện Lộc Ninh", ProvinceId = 15 },
                // Thêm các huyện khác của Bình Phước

                // Bình Thuận
               new DistrictModel { Id = 1601, Title = "Huyện Phan Thiết", ProvinceId = 16 },
               new DistrictModel { Id = 1602, Title = "Huyện Hàm Thuận Nam", ProvinceId = 16 },
               new DistrictModel { Id = 1603, Title = "Huyện Bắc Bình", ProvinceId = 16 },
               new DistrictModel { Id = 1604, Title = "Huyện Tánh Linh", ProvinceId = 16 },
                // Thêm các huyện khác của Bình Thuận

                // Cà Mau
               new DistrictModel { Id = 1701, Title = "Huyện Cà Mau", ProvinceId = 17 },
               new DistrictModel { Id = 1702, Title = "Huyện U Minh", ProvinceId = 17 },
               new DistrictModel { Id = 1703, Title = "Huyện Thới Bình", ProvinceId = 17 },
               new DistrictModel { Id = 1704, Title = "Huyện Trần Văn Thời", ProvinceId = 17 },
                // Thêm các huyện khác của Cà Mau

                // Cao Bằng
               new DistrictModel { Id = 1801, Title = "Huyện Cao Bằng", ProvinceId = 18 },
               new DistrictModel { Id = 1802, Title = "Huyện Bảo Lâm", ProvinceId = 18 },
               new DistrictModel { Id = 1803, Title = "Huyện Hà Quảng", ProvinceId = 18 },
               new DistrictModel { Id = 1804, Title = "Huyện Trùng Khánh", ProvinceId = 18 },
                // Thêm các huyện khác của Cao Bằng

                // Đắk Lắk
               new DistrictModel { Id = 1901, Title = "Huyện Buôn Hồ", ProvinceId = 19 },
               new DistrictModel { Id = 1902, Title = "Huyện Krông Búk", ProvinceId = 19 },
               new DistrictModel { Id = 1903, Title = "Huyện Krông Năng", ProvinceId = 19 },
               new DistrictModel { Id = 1904, Title = "Huyện Ea Kar", ProvinceId = 19 },
                // Thêm các huyện khác của Đắk Lắk

                // Đắk Nông
               new DistrictModel { Id = 2001, Title = "Huyện Krông Nô", ProvinceId = 20 },
               new DistrictModel { Id = 2002, Title = "Huyện Cư Jút", ProvinceId = 20 },
               new DistrictModel { Id = 2003, Title = "Huyện Đắk Mil", ProvinceId = 20 },
               new DistrictModel { Id = 2004, Title = "Huyện Tuy Đức", ProvinceId = 20 }
            };
            return districts;
        }

        public static List<WardModel> GetWardModels()
        {
            List<WardModel> wards = new List<WardModel>
            {
                new  WardModel{ Id = 1001, Title = "Phường Bến Thành", DistrictId = 101 }, // Bến Thành thuộc Quận 1
                new  WardModel{ Id = 1002, Title = "Phường Thảo Điền", DistrictId = 102 }, // Thảo Điền thuộc Quận 2
                // Thêm các xã khác tương tự
            };
            return wards;
        }
    }
}
