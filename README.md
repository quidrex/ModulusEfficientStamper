# Modulus mod: Efficient Stamper

## Description

This mod changes the behavior of Basic and Advanced Stampers to buffer a single additional output. This prevents unwanted scrapping in most circumstances.

## Installation

1. Install [ModulusModLoader](https://github.com/ModulusModding/ModulusModLoader)
2. Copy `EfficientStamper` directory into
   * Windows: `%userprofile%\Documents\My Games\Modulus\mods`
   * Proton: `~/.steam/steam/steamapps/compatdata/2779120/pfx/drive_c/users/steamuser/Documents/My Games/Modulus/mods/`

## Motivation

In vanilla, the stamper has a built-in overflow scrapper so that output belts (and other buildings) can be filled to capacity independently, which prevents
throughput issues. Unfortunately this can also lead to unwanted scrapping if the outputs are used not at the exact same time but in turns.

## Changes

Buffer a single additional output (either A or B) inside the stamper. This way, if 0 As and 1 B are buffered, when a stamp happens, now 1 A and 2
Bs are buffered. Only if there are 0 As and 2 Bs buffered, a stamp will scrap one B to fill the buffer to 1 A and 2 Bs.
