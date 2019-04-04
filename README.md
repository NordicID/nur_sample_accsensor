# nur_sample_accsensor
Sample code for accessory sensors API

# API overview

## AccSensorEnumerate

Use AccSensorEnumerate to get a list of the sensors connected to the reader.

# struct AccessorySensorConfig

Describes a sensor;
* source is the virtual I/O pin id for the sensor, there currently exist:
    * 130: USB sensor
* type describes what kind of sensor this is
* feature is a bitfield with values from enum AccessorySensorFeature describing what features the sensor supports
    * Range; indicating this is a range sensor and the range filter must be used to use it as a virtual I/O
    * StreamValue; this is a sensor that has values that can be streamed or read with AccSensorGetValue, the exact type of values returned depends on the sensor type (currently Range sensors can supply AccSensorRangeData)
* mode is a bitfield of with values from AccessorySensorMode; this is the only option in this struct that can be changed by the user of the API to enable it as a virtual I/O pin and/or to stream raw sensor values

# AccSensorGetConfig/AccSensorSetConfig

Used to get/set the sensor config (only mode can be changed).

# AccSensorSetFilter/AccSensorGetFilter

Used to get/set the filter options for the sensor.

# struct AccessorySensorFilter

Has a flag paramter of type enum AccessorySensorFilterFlag that describes what filters are enabled, currently range and time based filters exist.

Sensors with the Range feature can use the rangeThreshold to define when the virtual I/O 0/1 signals shold trigger.

All sensor types support the timeThreshold filter (a time based debounce filter).

# Events
## IOChangeEvent

Used by NurAPI for standard I/O pins, but also has a sensor flag that is set when a sensor configured as a virtual I/O pin changes state.

## AccessorySensorChangedEvent

When USB sensors are connected/disconnected to/from the reader, an event is sent here. Since this can happen dynamically, the application using the API must be prepared that sensors appear/disappear at runtime.

## AccessoryRangeDataEvent

When streaming of raw sensor values is enabled, and event with the sensor value is sent here (currently only Range sensors exist).
