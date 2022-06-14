module Client.Teabags.View

open Elmish
open Fable.Core.JsInterop
open Fable.Remoting.Client
open Feliz
open Feliz.Bulma



let view model dispatch =
  Bulma.container [
    prop.text "Get teabags"
  ]