## KonataDancing

### Overview

**KonataDancing** is a simple C# Windows Forms application that plays a frame-by-frame animation of Konata. The program loads frames from a specified folder and displays them in a loop. Additionally, the user can drag and move the form by clicking and holding on the animation area.

![Konata](https://github.com/LincolnCox29/KonataDancing/blob/master/frames/frame_0135.png)

### Features

- **Frame-by-Frame Animation:** Displays a series of frames from the `frames` folder, creating an animation effect.
- **Smooth Rendering:** Uses a custom `DoubleBufferedPictureBox` to reduce flickering.
- **Draggable Form:** Allows moving the application window by dragging on the animation area.

### Prerequisites

- **.NET Framework**
- A folder named `frames` in the root directory of the application, containing images in the format `frame_XXXX.png` (where `XXXX` is a 4-digit frame number).

### Installation

1. Clone or download this repository.
2. Place your animation frames in a folder named `frames` and icon.ico in the application directory. Ensure the frames are named in the format `frame_XXXX.png`.
3. Build the project using Visual Studio or a compatible C# IDE.

### Usage

- **Start Animation:** The animation starts automatically when the application runs.
- **Drag to Move:** Click and hold within the animation area to move the window.

### Frame Requirements

Ensure the frames are named in a zero-padded 4-digit format, such as:
- `frame_0001.png`
- `frame_0002.png`
- `frame_0003.png`
