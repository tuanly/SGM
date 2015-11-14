using System;
using System.Collections.Generic;
using System.Text;

namespace SGM_Core.Utils
{
    public class SGMText
    {
        public static string SGM_ERROR = "Lỗi";
        public static string SGM_WARNING = "Lưu ý";
        public static string SGM_QUESTION = "Xác nhận";
        public static string SGM_INFO = "Thông báo";

        public static string APP_NO_INTERNET_CONNECTION = "Lỗi, không có kết nối mạng!";
        public static string APP_SERVICE_TIME_OUT = "Lỗi, quá thời gian xử lý!";

        public static string GAS_STATION_LOGON_ID_INVALID = "Lỗi, ID đăng nhập không hợp lệ!";
        public static string GAS_STATION_LOGON_ERR = "Lỗi, Không thể đăng nhập hệ thống!";
        public static string GAS_STATION_LOGON_UPDATE_MACADR_ERR = "Lỗi, Không thể cập nhật Mac Address!";
        public static string GAS_STATION_CARD_ID_NOT_EXIST = "Lỗi, Thẻ không tồn tại!";
        public static string GAS_STATION_RECHARGE_ID_NOT_EXIST = "Lỗi, Recharge id không tồn tại!";


        public static string FRM_CONFIG_SAVE_CONFIG_ERR = "Lỗi! Không thể lưu thông tin cấu hình.";
        public static string FRM_CONFIG_LOAD_CONFIG_ERR = "Lỗi! Không thể lấy thông tin cấu hình.";
        public static string FRM_CONFIG_CANT_CONNECT_READER = "Lỗi! Không thể kết nối với máy quét thẻ.";
        public static string FRM_CONFIG_SAVE_CONFIG_SUCCESS = "Đã lưu thông tin cấu hình.";
        public static string GAS_92_TEXT = "Xăng 92";
        public static string GAS_95_TEXT = "Xăng 95";
        public static string GAS_DO_TEXT = "Dầu DO";
        public static string GAS_CARD_LOCK = "Thẻ xăng đã bị khóa.";
        
        

        public static string UPDATE_PRICE_INPUT_NULL = "Chưa nhập giá!";
        public static string UPDATE_PRICE_INPUT_ERR = "Giá không hợp lệ!";

        public static string ADMIN_LOGON_ERROR = "Lỗi, Không thể đăng nhập hệ thống!";

        public static string CUSTOMER_DATA_INPUT_CUS_ID_ERR = "Lỗi! Chưa nhập Mã khách hàng.";
        public static string CUSTOMER_DATA_INPUT_CUS_NAME_ERR = "Lỗi! Chưa nhập Tên khách hàng.";
        public static string CUSTOMER_DATA_INPUT_CUS_BIRTHDAY_ERR = "Lỗi! Chưa nhập Ngày Sinh khách hàng.";
        public static string CUSTOMER_DATA_INPUT_CUS_VISA_ERR = "Lỗi! Chưa nhập CMND khách hàng.";
        public static string CUSTOMER_DATA_INPUT_EXIST_CUS_ID_ERR = "Lỗi! ID khách hàng đã tồn tại.";
        public static string CUSTOMER_ADD_NEW_CUS_ERR = "Lỗi! Không thể thêm khách hàng.";
        public static string CUSTOMER_UPDATE_CUS_ERR = "Lỗi! Không thể thêm khách hàng.";
        public static string CUSTOMER_DEL_CUS_ERR = "Lỗi! Không thể xóa khách hàng.";
        public static string CUSTOMER_GET_CUS_ERR = "Lỗi! Không thể lấy thông tin khách hàng.";
        public static string CUSTOMER_DEL_CUS_SUCCESS = "Khách hàng đã xóa thành công";
        public static string CUSTOMER_DEL_CUS_WARNING = "Bạn có chắc muốn xóa khách hàng sau đây không?";
        public static string CUSTOMER_DEL_CUS = "Xóa Khách Hàng";

        public static string SYS_ADMIN_CHANGE_SUCCESS = "Đã cập nhật tài khoản admin.";
        public static string SYS_ADMIN_CHANGE_FAIL = "Cập nhật tài khoản admin không thành công.";
        public static string SYS_ADMIN_GET_PRICE_ERR = "Lỗi! Không thể lấy giá xăng.";
        public static string ADMIN_UPDATE_PRICE_SUCCESS = "Cập nhật giá thành công.";
        public static string ADMIN_UPDATE_PRICE_ERR = "Lỗi! Không thể cập nhật giá.";
        public static string ADMIN_UPDATE_TOTAL_SUCCESS = "Cập nhật tổng kho thành công.";
        public static string ADMIN_UPDATE_TOTAL_ERR = "Lỗi! Không thể cập nhật tổng kho.";

        public static string CARD_DATA_INPUT_EXIST_CARD_ID_ERR = "Lỗi! Card đã tồn tại!";
        public static string CARD_DATA_INPUT_CARD_ID_ERR = "Lỗi! Chưa nhập Mã Thẻ.";
        public static string CARD_DATA_INPUT_CARD_MONEY_ERR = "Lỗi! Chưa nhập Số tiền cho thẻ.";
        public static string CARD_DATA_INPUT_CARD_PRICE_ERR = "Lỗi! Chưa nhập Giá tiền mua thẻ.";
        public static string CARD_DATA_INPUT_CARD_MONEY_PRICE_ERR = "Lỗi! Giá mua không thể lớn hơn số tiền trên thẻ.";
        public static string CARD_DATA_INPUT_DATE_ERR = "Lỗi! Ngày mua card không được nhỏ hơn ngày hiện tại.";
        public static string CARD_GET_CARD_ERR = "Lỗi! Không thể lấy thông tin thẻ.";
        public static string CARD_GET_CARDS_ERR = "Lỗi! Không thể lấy danh sách thẻ.";
        public static string CARD_INSERT_ERR = "Lỗi! Không thể thêm thẻ";
        public static string CARD_RECHARGE_INSERT_ERR = "Lỗi! Không thể nạp thẻ";
        public static string CARD_UPDATE_RECHARGE_ID_ERR = "Lỗi! Không thể cập nhật thông tin nạp thẻ";
        public static string CARD_UPDATE_MONEY_ERR = "Lỗi! Không thể cập nhật thông tin nạp thẻ";
        public static string CARD_UPDATE_CARD_STATE_ERR = "Lỗi! Không thể cập nhật trạng thái thẻ.";

        public static string GASSTATION_GET_GS_ERR = "Lỗi! Không thể lấy thông tin trạm xăng.";
        public static string GASSTATION_ADD_NEW_GS_ERR = "Lỗi! Không thể thêm trạm xăng.";
        public static string GASSTATION_UPDATE_ERR = "Lỗi! Không thể cập nhật trạm xăng.";
        public static string GASSTATION_DEL_ERR = "Lỗi! Không thể xóa trạm xăng.";
        public static string GASSTATION_DEL_SUCCESS = "Trạm xăng đã xóa thành công.";
        public static string GASSTATION_DATA_INPUT_EXIST_GS_ID_ERR = "Lỗi! Mã Cây Xăng này đã tồn tại!";
        public static string GASSTATION_DATA_INPUT_GS_ID_ERR = "Lỗi! Chưa nhập Mã Cây Xăng.";
        public static string GASSTATION_DATA_INPUT_GS_NAME_ERR = "Lỗi! Chưa nhập Tên Cây Xăng.";
        public static string GASSTATION_DATA_INPUT_GS_ADDRESS_ERR = "Lỗi! Chưa nhập Địa chỉ.";

        public static string REPORT_NO_DATA = "Không có dữ liệu!";
        public static string REPORT_INPUT_DATE_ERROR = "Chọn khoảng thời gian ko hợp lệ!";
        public static string REPORT_INPUT_GASSTATION_EMPTY = "Danh sách Trạm Xăng rỗng";
        public static string REPORT_INPUT_CUSTOMER_EMPTY = "Danh sách Khách Hàng rỗng";
        public static string REPORT_ALL = "Tất Cả";

        public static string SALEGAS_LOGIN_INPUT_ERROR = "Lỗi, Chưa nhập mã đăng nhập!";
        public static string SALEGAS_MAIN_BILL = "Thanh Toán cho Thẻ : ";
        public static string SALEGAS_CARDINFO_LOCK = "Đang bị khóa.";
        public static string SALEGAS_CARDINFO_UNLOCK = "Đang hoạt động.";
        public static string SALEGAS_CURRENT_PRICE = "Giá xăng hiện tại: ";
        public static string GAS_BUYING_SUCCESS = "Mua xăng thành công.";
        public static string GAS_BUYING_FAIL = "Mua xăng không thành công.";
        public static string GAS_BUYING_INPUT_MONEY_INVALID = "Số tiền không hợp lệ!";
        public static string GAS_BUYING_INPUT_MONEY_FAIL = "Số tiền trong thẻ không đủ!";
        public static string GAS_BUYING_INPUT_TOTAL_GAS_FAIL = "Số xăng trong kho không đủ!";

        
    }
}
