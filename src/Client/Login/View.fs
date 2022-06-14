module Client.Login.View

open Elmish
open Fable.Core.JsInterop
open Fable.Remoting.Client
open Feliz
open Feliz.Bulma



let view model dispatch =
  Bulma.hero [
    Bulma.color.isLight
    Bulma.hero.isFullHeight
    prop.children [
      Bulma.heroBody [
        Bulma.container [
          text.hasTextCentered
          prop.children [
            Bulma.column [
              column.is4
              column.isOffset4
              prop.className "login"
              prop.children [
                Bulma.title.h3 [
                  Bulma.color.hasTextGrey
                  prop.text "The Collection"
                ]
                Bulma.box [
                  Bulma.image [
                    prop.className "avatar"
                    prop.children [
                      Html.img [ prop.src "/svg/teapot.svg" ]
                    ]
                  ]
                  Html.form [
                    Bulma.field.div [
                      Bulma.control.p [
                        Bulma.control.hasIconsLeft
                        prop.children [
                          Bulma.input.email [
                            prop.id "email"
                            prop.placeholder "your@email.com"
                          ]
                          Bulma.icon [
                            Bulma.icon.isSmall
                            Bulma.icon.isLeft
                            prop.children [
                              Html.i [
                                prop.className "fas fa-envelope"
                              ]
                            ]
                          ]
                        ]
                      ]
                    ]
                    Bulma.field.div [
                      Bulma.control.p [
                        Bulma.control.hasIconsLeft
                        prop.children [
                          Bulma.input.password [
                            prop.id "password"
                            prop.placeholder "*****"
                          ]
                          Bulma.icon [
                            Bulma.icon.isSmall
                            Bulma.icon.isLeft
                            prop.children [
                              Html.i [
                                prop.className "fas fa-key"
                              ]
                            ]
                          ]
                        ]
                      ]
                    ]
                    Bulma.button.button [
                      Bulma.color.isPrimary
                      Bulma.button.isFullWidth
                      prop.text "Login"
                    ]
                  ]
                ]
              ]
            ]
          ]
        ]
      ]
    ]
  ]