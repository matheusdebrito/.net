HTTPS -> Hyper Text Transfer Protocol Secure
    O HTTPS é uma extensão SEGURA do HTTP.
    TLS - Transport Layer Secure - permite a comunicação criptografada entre um site e um navegador e substitui o protocolo SSL - Secure Sockets Layer.
    Os sites que configurarem um certificado TLS podem utilizar o protocolo HTTPS para estabelecer uma comunicação segura com o servidor
    O objetivo do TLS é tornar segura a trasminssão de informações sensíveis como dados pessoais, de pagamento ou de login.

Ao criar o projeto ASP.NET Core são definidos middlewares:
    1 - HTTP de redirecionamento - app.UseHttpsRedirection - que redireciona uma requisição HTTP para HTTPS
    2 - HSTS - app.UseHsts - envia ao cliente um header Strict-Transport-Security(HSTS) que indica aos navegadores que nossa API deve ser acessada via HTTPS e não HTTP


