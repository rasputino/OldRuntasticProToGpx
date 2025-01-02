# Old Runtastic Pro to GPX Converter

This application converts activity data from the old Runtastic Pro app into GPX files with Garmin extensions. It enables users to export their activity data for compatibility with other platforms and tools that support the GPX format.

Did you miss the deadline to export your data from the old version of Runtastic PRO before it transitioned to the new Adidas app? Do you still have the smartphone or a backup of the data?

If so, this application can help you. Simply retrieve the database from your old phone, which should be located in a path similar to:

    Android/data/data/com.runtastic.android.pro2/databases/db

This should be the SQLite database containing your running session data.

Open the application, select this file, choose the destination folder where you want the GPX files to be saved, and click "Convert"

## Features

- **GPX Export**: Converts old Runtastic Pro activity data into GPX format.
- **Garmin Extensions**: Adds Garmin-specific extensions, including heart rate data, for enhanced compatibility.

## How It Works

1. **Input**: The application reads activity data from an SQLite database (`session` table).
2. **Processing**:
   - Parses GPS data (coordinates, elevation, speed, etc.).
   - Extracts heart rate and other session metadata.
   - Associates heart rate data with the nearest GPS timestamps.
3. **Output**: Generates a GPX file for each session with:
   - GPS points (`trkpt`) containing latitude, longitude, altitude, and timestamp.
   - Garmin extensions for heart rate (`hr`) when available.
4. **File Structure**: Each GPX file is named using the session ID.

## Usage

You can download the latest release or you can compile it.


![image](https://github.com/user-attachments/assets/a5967ef1-374c-451f-8af7-e664d6bc53fb)

