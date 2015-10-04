using System;
using System.Collections.Generic;
using System.Text;

namespace SGM_Core.DTO
{
    public class SGMText
    {
        public static string GAS_STATION_LOGON_ID_INVALID = "Lỗi, ID đăng nhập không hợp lệ!";
        public static string GAS_STATION_LOGON_ERR = "Lỗi, Không thể đăng nhập hệ thống!";
        public static string GAS_STATION_LOGON_UPDATE_MACADR_ERR = "Lỗi, Không thể cập nhật Mac Address!";
        public static string GAS_STATION_CARD_ID_NOT_EXIST = "Lỗi, Thẻ không tồn tại!";
        public static string GAS_STATION_RECHARGE_ID_NOT_EXIST = "Lỗi, Recharge id không tồn tại!";

        public static string FRM_CONFIG_SAVE_CONFIG_ERR = "Lỗi! Không thể lưu thông tin cấu hình.";
        public static string FRM_CONFIG_LOAD_CONFIG_ERR = "Lỗi! Không thể lấy thông tin cấu hình.";
        public static string FRM_CONFIG_CANT_CONNECT_READER = "Lỗi! Không thể kết nối với máy quét thẻ.";
        public static string FRM_CONFIG_SAVE_CONFIG_SUCCESS = "Đã lưu thông tin cấu hình.";
    }
}
