module Client.Teabag.View

open Elmish
open Fable.Core.JsInterop
open Fable.Remoting.Client
open Feliz
open Feliz.Bulma

open Client.Teabag.Types

let view model dispatch =
  Bulma.container [
    Bulma.tile [
      //Bulma.color.hasTextDanger
      prop.text model.count
    ]
  ]