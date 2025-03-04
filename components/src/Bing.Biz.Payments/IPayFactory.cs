﻿using Bing.Biz.Payments.Alipay.Abstractions;
using Bing.Biz.Payments.Core;
using Bing.Biz.Payments.Wechatpay.Abstractions;

namespace Bing.Biz.Payments
{
    /// <summary>
    /// 支付工厂
    /// </summary>
    public interface IPayFactory
    {
        /// <summary>
        /// 创建支付服务
        /// </summary>
        /// <param name="way">支付方式</param>
        IPayService CreatePayService(PayWay way);

        /// <summary>
        /// 创建支付宝回调通知服务
        /// </summary>
        IAlipayNotifyService CreateAlipayNotifyService();

        /// <summary>
        /// 创建支付宝返回服务
        /// </summary>
        IAlipayReturnService CreateAlipayReturnService();

        /// <summary>
        /// 创建支付宝条码支付服务
        /// </summary>
        IAlipayBarcodePayService CreateAlipayBarcodePayService();

        /// <summary>
        /// 创建支付宝二维码支付服务
        /// </summary>
        IAlipayQrCodePayService CreateAlipayQrCodePayService();

        /// <summary>
        /// 创建支付宝App支付服务
        /// </summary>
        IAlipayAppPayService CreateAlipayAppPayService();

        /// <summary>
        /// 创建支付宝电脑网站支付服务
        /// </summary>
        IAlipayPagePayService CreateAlipayPagePayService();

        /// <summary>
        /// 创建支付宝手机网站支付服务
        /// </summary>
        IAlipayWapPayService CreateAlipayWapPayService();

        /// <summary>
        /// 创建微信回调通知服务
        /// </summary>
        IWechatpayNotifyService CreateWechatpayNotifyService();

        /// <summary>
        /// 创建微信下载交易账单服务
        /// </summary>
        IWechatpayDownloadBillService CreateWechatpayDownloadBillService();

        /// <summary>
        /// 创建微信付款码支付服务
        /// </summary>
        IWechatpayPaymentCodePayService CreateWechatpayBarcodePayService();

        /// <summary>
        /// 创建微信JsApi支付服务
        /// </summary>
        IWechatpayJsApiPayService CreateWechatpayJsApiPayService();

        /// <summary>
        /// 创建微信App支付服务
        /// </summary>
        IWechatpayAppPayService CreateWechatpayAppPayService();

        /// <summary>
        /// 创建微信H5支付服务
        /// </summary>
        IWechatpayH5PayService CreateH5PayService();

        /// <summary>
        /// 创建微信小程序支付服务
        /// </summary>
        IWechatpayMiniProgramPayService CreateWechatpayMiniProgramPayService();
    }
}
