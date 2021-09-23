import os
import json

class GenericObject:
    def __init__(self):
        pass

class Configuration:
    def __init__(self, config_path: str):
        if not os.path.exists(config_path):
            raise Exception("Config file not found: ", config_path)

        config = None
        with open(config_path, "r") as input:
            config = input.readlines()
            config = "\n".join(config)
            config = json.loads(config)
        
        if config:
            for key in config:
                value = config[key]

                if isinstance(value,dict):
                    value = self.__generate_object(config[key])

                setattr(self, key, value)

    def __generate_object(self, settings:dict):
        go = GenericObject()

        for key in settings:
            go.__setattr__(key, settings[key])
        return go