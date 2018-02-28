export class PersonDescription {
  id: string;
  description: string;
  faceAttributes: FaceAttributes;
  tags: Tag[]
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

export class Tag {
  name: string;
}
