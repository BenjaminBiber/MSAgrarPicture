export interface Album {
  id: string;
  Name: string;
  Cover-Bild: { small: string; large: string; original: string };
  bilders?: Bilder[];
  bilders?: Bilder[];
}

export interface Bilder {
  id: string;
  Bild: { small: string; large: string; original: string };
  Bildunterschrift: string;
  IstTopBild: boolean;
  album?: Album;
  albums?: Album[];
}

export interface ImpressumsText {
  id: string;
  Text: string;
  Sortierreihenfolge: number;
  IstÜberschrift: boolean;
}

export interface Impressum {
  id: string;
  Überschrift: string;
}

export interface GalerieSeite {
  id: string;
  Überschrift: string;
}

export interface Homepage {
  id: string;
  Überschrift: string;
  Haupttext: string;
  Best Of Text: string;
  Info Text: string;
  Seitenbild: string;
  Hintergrundbild: string;
}

export interface About {
  id: string;
  Überschrift: string;
  Teilüberschrift: string;
  Teil Text: string;
  Teilüberschrift 2: string;
  Teil Text 2: string;
  Ich Bild: { small: string; large: string; original: string };
}

export interface Einstellungen {
  id: string;
  Logo: string;
  Instagram Link: string;
  Tiktok Link: string;
  Youtube Link: string;
}

export interface CreateUpdateAlbumDto {
  Name: string;
  Cover-Bild: { small: string; large: string; original: string };
  bilderIds?: string[];
}

export interface CreateUpdateBilderDto {
  Bild: { small: string; large: string; original: string };
  Bildunterschrift: string;
  IstTopBild: boolean;
  albumId?: string;
  albumIds?: string[];
}

export interface CreateUpdateImpressumsTextDto {
  Text: string;
  Sortierreihenfolge: number;
  IstÜberschrift: boolean;
}

export interface CreateUpdateImpressumDto {
  Überschrift: string;
}

export interface CreateUpdateGalerieSeiteDto {
  Überschrift: string;
}

export interface CreateUpdateHomepageDto {
  Überschrift: string;
  Haupttext: string;
  Best Of Text: string;
  Info Text: string;
  Seitenbild: string;
  Hintergrundbild: string;
}

export interface CreateUpdateAboutDto {
  Überschrift: string;
  Teilüberschrift: string;
  Teil Text: string;
  Teilüberschrift 2: string;
  Teil Text 2: string;
  Ich Bild: { small: string; large: string; original: string };
}

export interface CreateUpdateEinstellungenDto {
  Logo: string;
  Instagram Link: string;
  Tiktok Link: string;
  Youtube Link: string;
}
