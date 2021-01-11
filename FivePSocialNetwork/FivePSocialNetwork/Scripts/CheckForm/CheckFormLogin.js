$('.ui.form')
    .form({
        fields: {
            user_email: {
                identifier: 'user_email',
                rules: [
                    {
                        type: 'empty',
                        prompt: 'Vui lòng nhập email!'
                    },
                    {
                        type: 'email',
                        prompt: 'Vui lòng nhập email hợp lệ!'
                    }
                ]
            },
            user_pass: {
                identifier: 'user_pass',
                rules: [
                    {
                        type: 'empty',
                        prompt: 'Vui lòng nhập password!'
                    },
                    {
                        type: 'minLength[5]',
                        prompt: 'Vui lòng nhập mật khẩu hợp lệ!'
                    },
                    {
                        type: 'regExp',
                        value: /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/,
                        prompt: 'Mật khẩu phải có ký tự in hoa, ký tự thường, ký tự số, và ký tự đặc biệt!'
                    }

                ]
            },
        },
        inline: true,
        on: 'blur'
    })
    ;