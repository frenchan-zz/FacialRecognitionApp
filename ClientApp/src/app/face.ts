export class FaceApi {
  data: string;
}

export class Face {
  faceId: string;
  faceAttributes: FaceAttributes;
  makeup: Makeup;
}

export class FaceAttributes {
  age: number;
  gender: string;
  glasses: boolean;
  makeup: Makeup;
  hair: Hair;
}

export class Makeup {
  eyeMakeup: boolean;
  lipMakeup: boolean;
}

export class Hair {
  bald: boolean;
  hairColor: HairColor[];
}

export class HairColor {
  color: string;
}
