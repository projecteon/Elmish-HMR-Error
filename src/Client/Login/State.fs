module Client.Login.State

open Elmish

open Client.Login.Types

let init() =
  let initialModel = {
    count = 0
  }
  initialModel

let update (msg:Msg) model : Model*Cmd<Msg> =
  match msg with
  | _ -> model, Cmd.none