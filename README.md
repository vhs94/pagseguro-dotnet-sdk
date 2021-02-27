<div align="center">
  <img align="center"
    src="https://assets.pagseguro.com.br/access-fe/v0.1/_next/static/56cc59eb846acee7db86812a5278d6ba.svg"
    alt="pagseguro logo">
</div>

<br />
<br />
<br />

<p>
  <a href="#" target="_blank">
    <img alt="License: MIT" src="https://img.shields.io/badge/License-MIT-yellow.svg" />
  </a>
  <a href="#" target="_blank">
    <img alt="Downloads"
      src="https://img.shields.io/github/downloads/victorSantana09/pagseguro-dotnet-sdk/total.svg?style=flat" />
  </a>
  <a href="#" target="_blank">
    <img alt="Issues"
      src="https://img.shields.io/github/issues-raw/victorSantana09/pagseguro-dotnet-sdk.svg?maxAge=25000" />
  </a>
  <a href="#" target="_blank">
    <img alt="Pull Requests"
      src="https://img.shields.io/github/issues-pr/victorSantana09/pagseguro-dotnet-sdk.svg?style=flat" />
  </a>
  <a href="https://twitter.com/victorhsantana1" target="_blank">
    <img alt="Twitter: victorhsantana1" src="https://img.shields.io/twitter/follow/victorhsantana1.svg?style=social" />
  </a>
  <a href="#" target="_blank">
    <img alt="Issues" src="https://badges.frapsoft.com/os/v1/open-source.svg?v=103" />
  </a>
</p>


```
Este projeto disponibiliza Wrappers via pacote Nuget das APIs do PagSeguro para desenvolvedores .NET Core
```
Cada API deverá ter seu pacote correspondente. Atualmente o projeto conta com SDK para as seguintes APIs:
* [API Pagamento Recorrente](https://dev.pagseguro.uol.com.br/docs/pagamento-recorrente)


## Install

* **Package Manager Console (Visual Studio)**
```sh
Install-Package Pagseguro.Sdk.RecurringPayment
```

* **dotnet cli**
```sh
dotnet add package Pagseguro.Sdk.RecurringPayment
```

* **Via csproj**
```sh
<PackageReference Include="Pagseguro.Sdk.RecurringPayment" Version="0.0.2" />
```



## Uso
* **Configure o middleware abaixo com as opções desejadas**

```csharp
          services.AddRecurringPayment(new PagSeguroOptions()
            {
                Email = "email_conta",
                //caso deseje utilizar a sandbox do pagseguro
                SandboxMode = true,
                Token = "token_conta",
                //Preencher apenas se SandboxMode for true
                SandboxBuyerEmail = "c45631988515948156903@sandbox.pagseguro.com.br"
            });
```
* **Injete a service desejada no seu construtor**

```csharp
        public MinhaService(IPagseguroSessionService pagseguroService)
        {
            _pagseguroService = pagseguroService;
        }
```

* **Consuma a service**

```csharp
    var session = await _pagseguroService.NewSession();
```
* **_OBS.: Consulte o código para ver as services e seus métodos disponíveis_**

## Run tests

```sh
TODO: PR's com testes são bem vindos
```

## Autor

👤 **victorSantana09**

* Twitter: [@victorhsantana1](https://twitter.com/victorhsantana1)
* Github: [@victorSantana09](https://github.com/victorSantana09)

## 🤝 Contribuição

Contribuições, issues e feature requests são bem vindas!<br />Dê uma olhada nas [issues](https://github.com/victorSantana09/pagseguro-dotnet-sdk/issues). 

## Show your support

Dê uma ⭐️ se esse projeto te ajudou!

***
_This README was generated with ❤️ by [readme-md-generator](https://github.com/kefranabg/readme-md-generator)_
