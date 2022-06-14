namespace Client

open Fable.Import
open Thoth.Json

module LocalStorage =
  let load (decoder: Decoder<'T>) key: Result<'T, string> =
      let o = Browser.WebStorage.localStorage.getItem key
      if isNull o then
          "No item found in local storage with key " + key |> Error
      else
          Decode.fromString decoder o

  let delete key =
      Browser.WebStorage.localStorage.removeItem(key)

  let inline save key (data: 'T) =
      Browser.WebStorage.localStorage.setItem(key, Encode.Auto.toString(0, data))

module SessionStorage =
  let load (decoder: Decoder<'T>) key: Result<'T, string> =
      let o = Browser.WebStorage.sessionStorage.getItem key
      if isNull o then
          "No item found in local storage with key " + key |> Error
      else
          Decode.fromString decoder o

  let delete key =
      Browser.WebStorage.sessionStorage.removeItem(key)

  let inline save key (data: 'T) =
      Browser.WebStorage.sessionStorage.setItem(key, Encode.Auto.toString(0, data))
