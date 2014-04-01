<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="AdClick.hroot._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        body
        {
            font-size: 12px;
            line-height: 120%;
        }

        .div100
        {
            width: 100%;
            float: left;
            height: 30px;
            line-height: 30px;
            border-bottom: #e1e1e1 1px solid;
        }

        .div
        {
            float: left;
            height: 30px;
            line-height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="div100">
                <div class="div" style="width: 100px;">名称 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="TextBox1"></asp:RequiredFieldValidator></div>
                <div class="div" style="width: 150px;">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    
                </div>
            </div>

            <div class="div100">
                <div class="div" style="width: 100px;">链接 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="TextBox2"></asp:RequiredFieldValidator></div>
                <div class="div" style="width: 150px;">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    
                </div>
            </div>

            <div class="div100">
                <div class="div" style="width: 100px;">&nbsp;</div>
                <div class="div" style="width: 150px;">
                    <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" />
                </div>
            </div>

            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <div class="div100">
                        <div class="div" style="width: 100px;">产品</div>
                        <div class="div" style="width: 150px;">
                            添加时间
                        </div>
                        <div class="div" style="width: 150px;">
                            点击次数
                        </div>
                        <div class="div" style="width: 350px;">
                            跳转链接
                        </div>

                    </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="div100">
                        <div class="div" style="width: 100px;"><a href='<%# Eval("url") %>' target="_blank"><%# Eval("product") %></a></div>
                        <div class="div" style="width: 150px;">
                            <%# Eval("addtime") %>
                        </div>
                        <div class="div" style="width: 150px;">
                            <%# Eval("counts") %>
                        </div>
                        <div class="div" style="width: 350px;">
                            <%# GetUrl(Eval("id").ToString()) %>
                        </div>
                        <div class="div" style="width: 150px;">
                            <a href="detail.aspx?id=<%# Eval("id") %>" target="_blank">详情列表</a>
                            <a href="analytics.aspx?id=<%# Eval("id") %>" target="_blank">分析列表</a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
